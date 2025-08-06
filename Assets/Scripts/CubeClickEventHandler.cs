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
        bool willSpawn = Random.Range(MinChance, MaxChance) <= cube.SpawnChance;

        if (willSpawn == true)
        {
            var cubes = _spawner.Spawn(cube);
            _explosive.Explode(cubes, cube.transform.position);
        }
        else
        {
            _explosive.Explode(cube);
        }

        Destroy(cube.gameObject);
    }
}
