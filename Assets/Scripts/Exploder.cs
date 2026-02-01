using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _upwardsModifier;

    public void ExplosionCube(Transform transform)
    {
        float force = _explosionForce / transform.localScale.x;
        float radius = _explosionRadius / transform.localScale.x;

        foreach (Rigidbody cube in GetExplodebleCubes(transform.position, radius))
        {
            cube.AddExplosionForce(force, transform.position, radius, _upwardsModifier);
        }
    }

    public void ExplosionSplitCube(Vector3 explosionPosition, List<Rigidbody> explodebleCubes)
    {
        foreach (Rigidbody cube in explodebleCubes)
        {
            cube.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius, _upwardsModifier);
        }
    }

    private List<Rigidbody> GetExplodebleCubes(Vector3 position, float radius)
    {
        List<Rigidbody> cubes = new();

        Collider[] hits = Physics.OverlapSphere(position, radius);

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
