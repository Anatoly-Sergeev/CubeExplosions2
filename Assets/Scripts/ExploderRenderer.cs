using UnityEngine;

public class ExploderRenderer : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectExplosion;

    public void ExplosionRender(Vector3 position, Quaternion rotation)
    {
        Instantiate(_effectExplosion, position, rotation);
    }
}
