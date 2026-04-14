using UnityEngine;
using ALScripts.Core;

public class GameMediator : MonoBehaviour
{
    public static GameMediator Instance { get; private set; }

    [Header("Core Mission Objects")]
    [SerializeField] private AlarmTrigger alarmTrigger;
    [SerializeField] private Door missionDoor;

    [Header("Optional Existing Systems")]
    [SerializeField] private MonoBehaviour alarmSoundBehaviour;
    [SerializeField] private MonoBehaviour blinkingLightBehaviour;
    [SerializeField] private MonoBehaviour shipShakeBehaviour;

    [Header("Visitor Puzzle")]
    [SerializeField] private int totalSystemsToRestore = 3;
    private int restoredSystems = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void StartEmergency()
    {
        Debug.Log("Mediator: Starting emergency.");

        if (alarmSoundBehaviour != null)
        {
            alarmSoundBehaviour.SendMessage("PlayAlarm", SendMessageOptions.DontRequireReceiver);
        }

        if (blinkingLightBehaviour != null)
        {
            blinkingLightBehaviour.SendMessage("StartBlinking", SendMessageOptions.DontRequireReceiver);
        }

        if (shipShakeBehaviour != null)
        {
            shipShakeBehaviour.SendMessage("StartShake", SendMessageOptions.DontRequireReceiver);
        }
    }

    public void HandleSystemRestore(string systemName)
    {
        restoredSystems++;

        Debug.Log($"Mediator: {systemName} restored. Progress: {restoredSystems}/{totalSystemsToRestore}");

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowEndScreen(systemName + " Restored");
        }

        if (restoredSystems >= totalSystemsToRestore)
        {
            HandleRepair();
        }
    }

    public void HandleRepair()
    {
        Debug.Log("Mediator: All systems restored.");

        if (alarmTrigger != null)
        {
            alarmTrigger.StopEmergency();
        }

        if (alarmSoundBehaviour != null)
        {
            alarmSoundBehaviour.SendMessage("StopAlarm", SendMessageOptions.DontRequireReceiver);
        }

        if (blinkingLightBehaviour != null)
        {
            blinkingLightBehaviour.SendMessage("StopBlinking", SendMessageOptions.DontRequireReceiver);
        }

        if (shipShakeBehaviour != null)
        {
            shipShakeBehaviour.SendMessage("StopShake", SendMessageOptions.DontRequireReceiver);
        }

        if (missionDoor != null)
        {
            if (missionDoor.IsMissionDoor)
                missionDoor.ForceMissionClose();
            else
                missionDoor.CloseDoor();
        }

        Debug.Log("Mediator: Mission completed.");
    }
}