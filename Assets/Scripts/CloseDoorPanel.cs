using UnityEngine;

public class CloseDoorPanel : MonoBehaviour
{
    [SerializeField] private Door targetDoor;
    [SerializeField] private AlarmTrigger targetTrigger;

    public void Interact()
    {
        if (targetDoor != null)
        {
            targetDoor.CloseDoor();
        }

        if (targetTrigger != null)
        {
            targetTrigger.StopEmergency();
        }

        Debug.Log("Door closed and emergency stopped.");
    }
}