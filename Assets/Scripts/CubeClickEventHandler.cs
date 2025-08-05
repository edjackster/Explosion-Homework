using UnityEngine;

public class CubeClickEventHandler : MonoBehaviour
{
    private const float MinChance = 0;
    private const float MaxChance = 1;

    [SerializeField] private CubeClickEvent listener;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _explosive;

    private void OnEnable()
    {
        listener.Click += OnClick;
    }
    private void OnDisable()
    {
        listener.Click -= OnClick;
    }

    private void OnClick(Cube cube)
    {
        float spawnChance = cube.GetSpawnChance();

        if (WillSpawn(spawnChance) == true)
        {
            cube.MultiplieChance();
            var cubes = _spawner.Spawn(cube);
            _explosive.Explode(cubes, cube.transform.position);
        }

        Destroy(cube.gameObject);
    }

    private bool WillSpawn(float spawnChance)
    {
        return Random.Range(MinChance, MaxChance) <= spawnChance;
    }
}
