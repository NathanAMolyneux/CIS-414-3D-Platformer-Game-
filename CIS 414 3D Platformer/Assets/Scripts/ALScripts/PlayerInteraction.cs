using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactLayer;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            CloseDoorPanel panel = hit.collider.GetComponentInParent<CloseDoorPanel>();
            if (panel != null)
            {
                panel.Interact();
                return;
            }

            Door door = hit.collider.GetComponentInParent<Door>();
            if (door != null)
            {
                door.ToggleDoor();
                return;
            }
        }
    }
}