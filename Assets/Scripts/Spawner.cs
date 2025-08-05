using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnChanceMultiplier = .5f;
    [SerializeField] private float _sizeMultiplier = .5f;
    [SerializeField] private int _minSpawns = 2;
    [SerializeField] private int _maxSpawns = 6;
    [SerializeField] private Cube _prefab;

    public List<Cube> Spawn(Cube cube)
    {
        int cubesCount = Random.Range(_minSpawns, _maxSpawns);
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

            var newCube = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            result.Add(newCube);

            newCube.transform.localScale = cube.transform.localScale * _sizeMultiplier;
            newCube.SpawnChance = cube.SpawnChance * _spawnChanceMultiplier;
        }

        return result;
    }
}
