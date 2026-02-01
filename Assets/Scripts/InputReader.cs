using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int MouseButton = 0;

    [SerializeField] private Raycaster _raycaster;

    public event Action<Cube> CubeSelected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton) && _raycaster.TrySelectCube(out Cube cube))
        {
            CubeSelected?.Invoke(cube);
        }
    }
}
