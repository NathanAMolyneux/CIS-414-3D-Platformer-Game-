using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform door;
    [SerializeField] private Vector3 openPositionOffset = new Vector3(-4f, 0f, 0f);
    [SerializeField] private float speed = 4f;
    [SerializeField] private bool startHalfOpen = false;

    private Vector3 closedLocalPosition;
    private Vector3 openLocalPosition;
    private bool isOpen = false;

    private void Start()
    {
       
        closedLocalPosition = door.localPosition;
        openLocalPosition = closedLocalPosition + openPositionOffset;

        if (startHalfOpen)
        {
            door.localPosition = Vector3.Lerp(closedLocalPosition, openLocalPosition, 0.5f);
            isOpen = true;
        }
    }

    private void Update()
    {
        Vector3 target = isOpen ? openLocalPosition : closedLocalPosition;
        door.localPosition = Vector3.Lerp(door.localPosition, target, Time.deltaTime * speed);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        Debug.Log("Door toggled: " + isOpen);
    }

    public void CloseDoor()
    {
        isOpen = false;
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
}