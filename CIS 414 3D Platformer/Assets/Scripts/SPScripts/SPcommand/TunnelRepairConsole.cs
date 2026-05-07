using UnityEngine;

public class TunnelRepairConsole : MonoBehaviour
{
    [SerializeField] private NewSceneLoader sceneLoader;
    private bool playerInside = false;
    private bool repaired = false;

    private IActionCommand repairCommand;

    private void Start()
    {
        repairCommand = new UnlockTunnelCommand(sceneLoader);
    }

    private void Update()
    {
        if (playerInside && !repaired && Input.GetKeyDown(KeyCode.E))
        {
            repaired = true;

            if (repairCommand != null)
            {
                repairCommand.Execute();
            }
            MissionManager missionManager = FindObjectOfType<MissionManager>();
            if (missionManager != null)
            {
                missionManager.SetMissionStep(4);
            }
            Debug.Log("Console repaired with Command Pattern.");
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}