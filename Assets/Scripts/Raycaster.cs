using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _input;

    private Ray _ray;

    public event Action<Cube> CubeSelected;

    private void OnEnable()
    {
        _input.Onclick += SelectCube;
    }

    private void OnDisable()
    {
        _input.Onclick -= SelectCube;
    }

    public void SelectCube(Vector3 position)
    {
        _ray = _camera.ScreenPointToRay(position);

        if (Physics.Raycast(_ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                CubeSelected?.Invoke(cube);
            }
        }
    }
}
