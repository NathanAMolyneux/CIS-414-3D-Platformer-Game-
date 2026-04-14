using TMPro;
using UnityEngine;
using ALScripts.Existing;

public class BreachMissionController : MonoBehaviour
{
    public static BreachMissionController Instance { get; private set; }

    [Header("Mission Door")]
    [SerializeField] private Door missionDoor;

    [Header("Emergency Systems")]
    [SerializeField] private AlarmSound alarmSound;
    [SerializeField] private SpaceAnomaly[] anomalyObjects;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private TextMeshProUGUI breachesText;

    [Header("Mission Settings")]
    [SerializeField] private int totalBreaches = 1;
    [SerializeField] private bool missionStarted = true;

    private int fixedBreaches = 0;
    private bool missionCompleted = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if (missionStarted)
        {
            StartEmergency();
        }
    }

    public void StartEmergency()
    {
        missionCompleted = false;

        if (missionDoor != null)
        {
            missionDoor.ForceMissionOpen();
        }

        if (alarmSound != null)
        {
            alarmSound.PlayAlarm();
        }

        for (int i = 0; i < anomalyObjects.Length; i++)
        {
            if (anomalyObjects[i] != null)
            {
                anomalyObjects[i].ActivateAnomaly();
            }
        }

        UpdateUI("Emergency repair in progress");
    }

    public void CompleteRepair()
    {
        if (missionCompleted) return;

        missionCompleted = true;
        fixedBreaches++;

        if (missionDoor != null)
        {
            missionDoor.ForceMissionClose();
        }

        if (alarmSound != null)
        {
            alarmSound.StopAlarm();
        }

        for (int i = 0; i < anomalyObjects.Length; i++)
        {
            if (anomalyObjects[i] != null)
            {
                anomalyObjects[i].DeactivateAnomaly();
            }
        }

        if (fixedBreaches >= totalBreaches)
        {
            UpdateUI("All systems stable");
        }
        else
        {
            UpdateUI("Repair completed");
        }

        Debug.Log("Mission repair completed.");
    }

    private void UpdateUI(string statusMessage)
    {
        if (statusText != null)
        {
            statusText.text = $"Status: {statusMessage}";
        }

        if (breachesText != null)
        {
            breachesText.text = $"Breaches Fixed: {fixedBreaches}/{totalBreaches}";
        }
    }
}