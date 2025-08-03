using UnityEngine;

public class MouseClickExploder : MonoBehaviour
{
    [SerializeField] private LayerMask mask;

    private void Update()
    {
        OnLeftMouseClick();
    }

    private void OnLeftMouseClick()
    {
        if (Input.GetMouseButtonDown(0) == false) return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            hit.transform.GetComponent<Explosive>().Explode();
        }
    }
}
