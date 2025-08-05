using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private const float SizeMultiplier = .5f;
    [SerializeField] private int minSpawns = 2;
    [SerializeField] private int maxSpawns = 6;

    public List<Cube> Spawn(Cube cube)
    {
        int cubesCount = Random.Range(minSpawns, maxSpawns);
        List<Cube> result = new List<Cube>();

        for (int i = 0; i < cubesCount; i++)
        {
            float minDelta = -1f;
            float maxDelta = 1f;
            float shiftDevider = 2;

            float deltaY = 0.1f;
            float deltaX = Random.Range(minDelta, maxDelta);
            float deltaZ = Random.Range(minDelta, maxDelta);

            var direction = new Vector3(deltaX, deltaY, deltaZ).normalized;
            var shift = direction * cube.transform.localScale.magnitude / shiftDevider;
            var spawnPosition = cube.transform.position + shift;

            var newCube = Instantiate(cube, spawnPosition, Quaternion.identity);
            result.Add(newCube);

            newCube.transform.localScale = cube.transform.localScale * SizeMultiplier;
        }

        return result;
    }
}
