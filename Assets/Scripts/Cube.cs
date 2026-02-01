using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> ClickedToDestroy;

    public float DivideChance { get; private set; }

    private void OnMouseDown()
    {
        ClickedToDestroy?.Invoke(this);
    }

    public void Init(float chance)
    {
        DivideChance = chance;
    }
}
