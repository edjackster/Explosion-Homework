using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _spawnChance = 1f;

    public float SpawnChance { 
        get => _spawnChance; 
        set
        {
            _spawnChance = value;
        }
    }
}
