using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> OnSelfDestroy;

    public float DivideChance { get; private set; }

    public void Die()
    {
        OnSelfDestroy?.Invoke(this);
    }

    public void Init(float chance)
    {
        DivideChance = chance;
    }
}
