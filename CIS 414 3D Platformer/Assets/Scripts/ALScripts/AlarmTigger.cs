using UnityEngine;



public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private AlarmSound alarmSound;
    [SerializeField] private bool emergencyActive = true;

    private void OnTriggerStay(Collider other)
    {
        if (!emergencyActive) return;

        if (other.CompareTag("Player"))
        {
            if (alarmSound != null)
            {
                alarmSound.PlayAlarm();
            }

            foreach (var obj in FindObjectsOfType<SpaceAnomaly>())
            {
                obj.ActivateAnomaly();
            }
        }
    }

    public void StopEmergency()
    {
        emergencyActive = false;

        if (alarmSound != null)
        {
            alarmSound.StopAlarm();
        }

        foreach (var obj in FindObjectsOfType<SpaceAnomaly>())
        {
            obj.DeactivateAnomaly();
        }

        Debug.Log("Emergency fully stopped.");
    }
}