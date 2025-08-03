using UnityEngine;

public class Explosive : MonoBehaviour
{
    private const float SpawnChanceMultiplier = .5f;
    private const float SizeMultiplier = .5f;
    private const float ExplosionPowerMultiplier = 1.5f;
    private const float ExplosionRangeMultiplier = 2f;
    private const float MinChance = 0;
    private const float MaxChance = 1;

    [SerializeField] private GameObject _cube;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float _spawnChance = 1f;
    [SerializeField] private float _explosionRange = 2.5f;
    [SerializeField] private float _explosionPower = 1f;

    private int minSpawns = 2;
    private int maxSpawns = 6;

    private bool WillSpawn { get => Random.Range(MinChance, MaxChance) < _spawnChance; }

    public void Explode()
    {
        Destroy(gameObject);

        if (WillSpawn == true)
        {
            int cubesCount = Random.Range(minSpawns, maxSpawns);
            SpawCubes(cubesCount);
        }
        else
        {
            PushBlocksInRadius();
        }
    }

    public void SetExplosinParametrs(float range, float power, float spawnChance)
    {
        _explosionRange = range;
        _explosionPower = power;
        _spawnChance = spawnChance;
    }

    private void PushBlocksInRadius()
    {
        var position = transform.position;
        var hits = Physics.SphereCastAll(position, _explosionRange, Vector3.one, maxDistance: _explosionRange, mask);

        foreach (var hit in hits)
        {
            if (hit.transform.gameObject == gameObject)
                continue;

            var _explosionPowerDirection = (hit.transform.position - position);

            hit.rigidbody.velocity = _explosionPowerDirection.normalized / (_explosionPowerDirection.magnitude / _explosionRange) * _explosionPower;
        }
    }

    private void SpawCubes(int cubesCount)
    {
        for (int i = 0; i < cubesCount; i++)
        {
            float minDelta = -1f;
            float maxDelta = 1f;
            float shiftDevider = 2;

            float deltaY = 0.1f;
            float deltaX = Random.Range(minDelta, maxDelta);
            float deltaZ = Random.Range(minDelta, maxDelta);

            var direction = new Vector3(deltaX, deltaY, deltaZ).normalized;
            var shift = direction * transform.localScale.magnitude / shiftDevider;
            var spawnPosition = transform.position + shift;

            var cube = Instantiate(_cube, spawnPosition, Quaternion.identity);
            var explosive = cube.GetComponent<Explosive>();
            var rigidbody = cube.GetComponent<Rigidbody>();

            rigidbody.velocity = direction * _explosionPower;
            cube.transform.localScale = transform.localScale * SizeMultiplier;
            explosive.SetExplosinParametrs(_explosionRange * ExplosionRangeMultiplier, _explosionPower * ExplosionPowerMultiplier, _spawnChance * SpawnChanceMultiplier);
        }
    }
}
