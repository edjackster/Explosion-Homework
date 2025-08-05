using UnityEngine;

public class ClickEventHandler : MonoBehaviour
{
    private const float MinChance = 0;
    private const float MaxChance = 1;

    [SerializeField] private CubeClickListener listener;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _explosive;

    private void Start()
    {
        listener.Click += Click;
    }

    private void Click(Cube cube)
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
