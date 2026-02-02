using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int MouseButton = 0;

    public event Action<Vector3> Onclick;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
        {
            Onclick?.Invoke(Input.mousePosition);
        }
    }
}
