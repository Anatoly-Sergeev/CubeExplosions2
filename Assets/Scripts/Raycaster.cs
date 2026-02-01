using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ray _ray;

    public bool TrySelectCube(out Cube cube)
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        cube = null;

        if (Physics.Raycast(_ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out cube))
            {
                return true;
            }
        }

        return false;
    }
}
