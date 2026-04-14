using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private Vector3 openPositionOffset = new Vector3(-4f, 0f, 0f);
    [SerializeField] private float speed = 4f;
    [SerializeField] private bool startHalfOpen = false;
    [SerializeField] private float autoCloseDelay = 10f;
    [SerializeField] private bool isMissionDoor = false;

    private Vector3 closedLocalPosition;
    private Vector3 openLocalPosition;
    private bool isOpen = false;
    private float autoCloseTimer = 0f;

    public bool IsMissionDoor => isMissionDoor;
    public bool IsOpen => isOpen;

    private void Start()
    {
        if (door == null)
        {
            Debug.LogWarning($"{name}: Door transform is not assigned.");
            enabled = false;
            return;
        }

        closedLocalPosition = door.localPosition;
        openLocalPosition = closedLocalPosition + openPositionOffset;

        if (startHalfOpen)
        {
            door.localPosition = Vector3.Lerp(closedLocalPosition, openLocalPosition, 0.5f);
            isOpen = true;
        }
        else
        {
            door.localPosition = closedLocalPosition;
            isOpen = false;
        }
    }

    private void Update()
    {
        Vector3 target = isOpen ? openLocalPosition : closedLocalPosition;
        door.localPosition = Vector3.Lerp(door.localPosition, target, Time.deltaTime * speed);

        if (isMissionDoor) return;

        if (isOpen)
        {
            autoCloseTimer -= Time.deltaTime;

            if (autoCloseTimer <= 0f)
            {
                CloseDoor();
            }
        }
    }

    public void ToggleDoor()
    {
        if (isMissionDoor)
        {
            Debug.Log($"{name}: Mission door ignores normal toggle.");
            return;
        }

        if (isOpen) CloseDoor();
        else OpenDoor();
    }

    public void OpenDoor()
    {
        isOpen = true;
        autoCloseTimer = autoCloseDelay;
        Debug.Log($"{name}: Door opened.");
    }

    public void CloseDoor()
    {
        isOpen = false;
        autoCloseTimer = 0f;
        Debug.Log($"{name}: Door closed.");
    }

    public void ForceMissionClose()
    {
        isOpen = false;
        autoCloseTimer = 0f;
        Debug.Log($"{name}: Mission door forcibly closed.");
    }

    public void ForceMissionOpen()
    {
        isOpen = true;
        autoCloseTimer = 0f;
        Debug.Log($"{name}: Mission door forcibly opened.");
    }
}