using UnityEngine;

public class CloseDoorPanel : MonoBehaviour
{
    public void Interact()
    {
        if (GameMediator.Instance != null)
        {
            GameMediator.Instance.HandleRepair();
        }
        else
        {
            Debug.LogWarning("No GameMediator found.");
        }
    }
}