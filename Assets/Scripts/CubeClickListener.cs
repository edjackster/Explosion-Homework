using System;
using UnityEngine;

public class CubeClickListener : MonoBehaviour
{
    private const float maxDistance = 100;

    [SerializeField] private LayerMask mask;

    public event Action<Cube> Click;

    private void Update()
    {
        OnLeftMouseClick();
    }

    private void OnLeftMouseClick()
    {
        if (Input.GetMouseButtonDown(0) == false) 
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Cube cube;

        if (Physics.Raycast(ray, out hit, maxDistance, mask) == false)
            return;

        if (hit.collider.TryGetComponent(out cube) == false)
            return; 

        Click?.Invoke(cube);
    }
}
