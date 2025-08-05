using UnityEngine;

public class Cube : MonoBehaviour
{

    [SerializeField] private float _spawnChanceMultiplier = .5f;
    [SerializeField] private float _spawnChance = .5f;

    public float GetSpawnChance()
    {
        return _spawnChance;
    }

    public void MultiplieChance()
    {
        _spawnChance *= _spawnChanceMultiplier;
    }
}
