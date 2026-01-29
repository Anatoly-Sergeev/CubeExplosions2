using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float DivideChance { get; private set; }

    public event Action<Cube> ClickedToDestroy;

    private void OnMouseDown()
    {
        ClickedToDestroy?.Invoke(this);
    }

    public void Init(float chance)
    {
        DivideChance = chance;
    }
}
