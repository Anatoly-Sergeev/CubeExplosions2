using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] float _explosionForce;
    [SerializeField] float _explosionRadius;
    [SerializeField] float _upwardsModifier;

    public void ExplosionCubes(Vector3 explosionPosition, List<Rigidbody> cubes)
    {
        foreach (Rigidbody cube in cubes)
        {
            cube.AddExplosionForce(_explosionForce, explosionPosition, _explosionRadius, _upwardsModifier);
        }
    }
}
