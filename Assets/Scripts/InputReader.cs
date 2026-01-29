using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int MouseButton = 0;

    [SerializeField] private Camera _ñamera;

    public event Action<Cube> CubeSelected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
        {
            Ray ray = _ñamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    CubeSelected?.Invoke(cube);
                }
            }
        }
    }
}
