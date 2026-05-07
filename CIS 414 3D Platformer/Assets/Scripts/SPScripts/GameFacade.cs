using UnityEngine;

public class GameFacade : MonoBehaviour
{
    public MissionManager missionManager;
    public PuzzleMessageUI puzzleUI;

    public void RepairCompleted()
    {
        if (missionManager != null)
            missionManager.SetMissionStep(1);

        if (puzzleUI != null)
            puzzleUI.ShowMessage("Repair completed. Find the energy core.");
    }

    public void EnergyCorePicked()
    {
        if (missionManager != null)
            missionManager.SetMissionStep(2);

        if (puzzleUI != null)
            puzzleUI.ShowMessage("Energy core acquired. Return to the slot.");
    }

    public void EnergyCoreInserted()
    {
        if (missionManager != null)
            missionManager.SetMissionStep(3);

        if (puzzleUI != null)
            puzzleUI.ShowMessage("Energy core installed. System restored.");
    }

    public void MissionCompleted()
    {
        if (missionManager != null)
            missionManager.SetMissionStep(4);

        if (puzzleUI != null)
            puzzleUI.ShowMessage("All objectives complete!");
    }
}