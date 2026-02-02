using System.Collections.Generic;
using UnityEngine;

public class Divider : MonoBehaviour
{
    private const int MinCubesCount = 2;
    private const int MaxCubesCount = 6;
    private const float HalfFactor = 0.5f;

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _raycaster.CubeSelected += DividingCubes;
    }

    private void OnDisable()
    {
        _raycaster.CubeSelected -= DividingCubes;
    }

    private void DividingCubes(Cube cube)
    {
        if (CanDividing(cube.DivideChance))
        {
            Vector3 scale = DecreaseCubeScale(cube.transform.localScale);
            float chance = DecreaseDivideChance(cube.DivideChance);
            List<Rigidbody> cubes = _spawner.SpawnCubes(GetRandomCubesCount(), cube.transform.position, cube.transform.rotation, scale, chance);

            _exploder.ExplosionSplitCube(cube.transform.position, cubes);
        }
        else
        {
            _exploder.ExplosionCube(cube.transform);
        }

        cube.Die();
    }

    private int GetRandomCubesCount()
    {
        return Random.Range(MinCubesCount, MaxCubesCount + 1);
    }

    private Vector3 DecreaseCubeScale(Vector3 scale)
    {
        return scale * HalfFactor;
    }

    private float DecreaseDivideChance(float chance)
    {
        return chance * HalfFactor;
    }

    private bool CanDividing(float chance)
    {
        return Random.value <= chance;
    }
}
