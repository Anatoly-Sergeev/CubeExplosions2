using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ExploderRenderer _exploderRenderer;
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _upwardsModifier;

    public void ExplosionCube(Vector3 explosionPosition, Quaternion rotation, Vector3 scale)
    {
        foreach (Rigidbody cube in GetExplodebleCubes(explosionPosition, _explosionRadius))
        {
            cube.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius, _upwardsModifier);
        }

        _exploderRenderer.ExplosionRender(explosionPosition, rotation);
    }

    private List<Rigidbody> GetExplodebleCubes(Vector3 position, float radius)
    {
        List<Rigidbody> cubes = new();

        Collider[] hits = Physics.OverlapSphere(position, radius);

        foreach (Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
