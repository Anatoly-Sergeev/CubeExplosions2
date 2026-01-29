using UnityEngine;

public class Divider : MonoBehaviour
{
    private const int MinCubesCount = 2;
    private const int MaxCubesCount = 6;
    private const float HalfFactor = 0.5f;

    [SerializeField] private Spawner _spawn;
    [SerializeField] private InputReader _input;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _input.CubeSelected += DividingCubes;
    }

    private void OnDisable()
    {
        _input.CubeSelected -= DividingCubes;
    }

    private void DividingCubes(Cube cube)
    {
        if (CanDividing(cube.DivideChance))
        {
            _spawn.SpawnCubes(GetRandomCubesCount(), cube.transform.position, cube.transform.rotation, DecreaseCubeScale(cube.transform.localScale), DecreaseDivideChance(cube.DivideChance));
        }
        else
        {
            _exploder.ExplosionCube(cube.transform.position, cube.transform.rotation, cube.transform.localScale);
        }
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
