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
}
