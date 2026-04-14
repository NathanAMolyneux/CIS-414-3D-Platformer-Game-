using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    private bool emergencyActive = true;
    private bool alreadyTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!emergencyActive) return;
        if (alreadyTriggered) return;

        if (other.CompareTag("Player"))
        {
            alreadyTriggered = true;

            if (GameMediator.Instance != null)
            {
                GameMediator.Instance.StartEmergency();
            }

            Debug.Log("Emergency triggered.");
        }
    }

    public void StopEmergency()
    {
        emergencyActive = false;
        Debug.Log("Emergency stopped.");
    }
}