using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefabCube;
    [SerializeField] private Painter _painter;

    private void Start()
    {
        const int StartCubeCount = 13;
        const float StartDivideChance = 1f;

        SpawnCubes(StartCubeCount, Vector3.up, Quaternion.identity, Vector3.one, StartDivideChance);
    }

    public List<Rigidbody> SpawnCubes(int count, Vector3 position, Quaternion rotation, Vector3 scale, float divideChance)
    {
        List<Rigidbody> cubes = new();
        List<Vector3> positions = GetSpawnPositions(count, position, scale);

        for (int i = 0; i < count; i++)
        {
            Cube cube = Instantiate(_prefabCube, positions[i], rotation);
            cube.transform.localScale = scale;
            cube.Init(divideChance);
            cube.ClickedToDestroy += DestroyCube;

            if (cube.TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _painter.GetRandomColor();
            }

            if (cube.TryGetComponent(out Rigidbody rigidbody))
            {
                cubes.Add(rigidbody);
            }
        }

        return cubes;
    }

    private void DestroyCube(Cube cube)
    {
        cube.ClickedToDestroy -= DestroyCube;

        Destroy(cube.gameObject);
    }

    private List<Vector3> GetSpawnPositions(int countPosition, Vector3 originPosition, Vector3 scale)
    {
        const float HalfFactor = 0.5f;
        const float GapFactor = 1.02f;

        List<Vector3> positions = new();
        List<Vector3> spawnPoints = new();

        float gap = scale.x * GapFactor;

        spawnPoints.Add(originPosition - (scale * HalfFactor));
        spawnPoints.Add(spawnPoints[0] + new Vector3(gap, 0, 0));
        spawnPoints.Add(spawnPoints[0] + new Vector3(0, 0, gap));
        spawnPoints.Add(spawnPoints[2] + new Vector3(gap, 0, 0));

        for (int i = 0; i < (float)countPosition / spawnPoints.Count; i++)
        {
            for (int j = 0; j < spawnPoints.Count; j++)
            {
                if (positions.Count <= countPosition)
                {
                    positions.Add(spawnPoints[j] + new Vector3(0, gap * i, 0));
                }
            }
        }

        return positions;
    }
}
