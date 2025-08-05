using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRange = 2.5f;
    [SerializeField] private float _explosionPower = 1f;

    public void Explode(List<Cube> cubes, Vector3 center)
    {
        cubes.ForEach(cube =>
        {
            if(cube.TryGetComponent(out Rigidbody rigidbody)){
                var direction = (cube.transform.position - center).normalized;
                rigidbody.velocity = direction * _explosionPower;
            }
        });
    }

    //Нужно для следующего задания
    private void Explode()
    {
        var position = transform.position;
        var hits = Physics.SphereCastAll(position, _explosionRange, Vector3.one, maxDistance: _explosionRange);

        foreach (var hit in hits)
        {
            if (hit.transform.gameObject == gameObject)
                continue;

            var _explosionPowerDirection = (hit.transform.position - position);

            hit.rigidbody.velocity = _explosionPowerDirection.normalized / (_explosionPowerDirection.magnitude / _explosionRange) * _explosionPower;
        }
    }
}
