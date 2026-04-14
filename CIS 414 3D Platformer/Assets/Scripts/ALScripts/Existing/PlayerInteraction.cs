using UnityEngine;
using ALScripts.Commands;

namespace ALScripts.Existing
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Transform cameraHolder;
        [SerializeField] private float interactDistance = 5f;

        private Camera playerCamera;
        private bool canRepair = false;
        private RepairVisitor repairVisitor = new RepairVisitor();

        private void Start()
        {
            if (cameraHolder != null)
            {
                playerCamera = cameraHolder.GetComponentInChildren<Camera>();
            }

            if (playerCamera == null)
            {
                playerCamera = Camera.main;
            }

            if (playerCamera == null)
            {
                Debug.LogWarning("PlayerInteraction: No camera found.");
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (TryInteractWithVisitorObject())
                {
                    return;
                }

                if (canRepair)
                {
                    Debug.Log("Repair triggered");
                    ICommand repairCommand = new RepairCommand();
                    repairCommand.Execute();
                    return;
                }

                TryInteractWithDoor();
            }
        }

        private bool TryInteractWithVisitorObject()
        {
            if (playerCamera == null)
            {
                Debug.LogWarning("PlayerInteraction: playerCamera is missing.");
                return false;
            }

            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactDistance, Color.cyan, 1f);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                Debug.Log("Ray hit: " + hit.collider.name);

                IShipVisitable visitable = hit.collider.GetComponent<IShipVisitable>();

                if (visitable == null)
                {
                    visitable = hit.collider.GetComponentInParent<IShipVisitable>();
                }

                if (visitable != null)
                {
                    visitable.Accept(repairVisitor);
                    Debug.Log("Visitor interaction triggered.");
                    return true;
                }
            }

            return false;
        }

        private void TryInteractWithDoor()
        {
            if (playerCamera == null)
            {
                Debug.LogWarning("PlayerInteraction: playerCamera is missing.");
                return;
            }

            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactDistance, Color.red, 1f);

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
            {
                Debug.Log("Ray hit: " + hit.collider.name);

                Door door = hit.collider.GetComponentInParent<Door>();

                if (door != null)
                {
                    door.ToggleDoor();
                }
                else
                {
                    Debug.Log("Hit object is not a door.");
                }
            }
            else
            {
                Debug.Log("Raycast hit nothing.");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("RepairZone"))
            {
                canRepair = true;
                Debug.Log("Entered Repair Zone");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("RepairZone"))
            {
                canRepair = false;
                Debug.Log("Exited Repair Zone");
            }
        }
    }
}