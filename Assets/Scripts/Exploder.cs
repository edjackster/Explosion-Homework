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

    public void Explode(Cube cube)
    {
        var position = cube.transform.position;
        var hits = Physics.SphereCastAll(position, _explosionRange, Vector3.one, _explosionRange);
        float scaledRange = _explosionRange / cube.transform.localScale.magnitude;
        float scaledPower = _explosionPower / cube.transform.localScale.magnitude;

        foreach (var hit in hits)
        {
            if (hit.rigidbody == null)
                continue;

            if (hit.transform.gameObject == cube.gameObject)
                continue;

            var positionDifference = (hit.transform.position - position);
            var direction = positionDifference.normalized;
            var rangedPower = scaledPower / (positionDifference.magnitude / scaledRange);
    
            if(hit.rigidbody)
                hit.rigidbody.velocity = direction * rangedPower;
        }
    }
}
