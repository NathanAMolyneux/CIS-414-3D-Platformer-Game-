using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public PuzzleMessageUI puzzleUI;

    public GameObject repairMarker;
    public GameObject energyCoreMarker;
    public GameObject energySlotMarker;
    public GameObject nextPuzzleMarker;

    private int missionStep = 0;

    private void Start()
    {
        SetMissionStep(0);
    }

    public void SetMissionStep(int step)
    {
        missionStep = step;

        repairMarker.SetActive(false);
        energyCoreMarker.SetActive(false);
        energySlotMarker.SetActive(false);
        nextPuzzleMarker.SetActive(false);

        if (missionStep == 0)
        {
            repairMarker.SetActive(true);
            puzzleUI.SetObjective("Puzzle: Tunnel gravity has been unstable so Find 2 node and Press E in order out of 3 to stabalize gravity. Follow the green signal.");
            puzzleUI.ShowMessage("Task 1/3: Repair the power node.");
        }
        else if (missionStep == 1)
        {
            energyCoreMarker.SetActive(true);
            puzzleUI.SetObjective("Puzzle: Spaceship power slot is damaged. find energy core chip.");
            puzzleUI.ShowMessage("Task 2/3: Find the energy core.");
        }
        else if (missionStep == 2)
        {
            energySlotMarker.SetActive(true);
            puzzleUI.SetObjective("Puzzle:Your Job is to find energy slot and Insert the energy core.");
            puzzleUI.ShowMessage("Task 2/3: Insert the energy core.");
        }
        else if (missionStep == 3)
        {
            nextPuzzleMarker.SetActive(true);
            puzzleUI.SetObjective("Puzzle: This place is not good to stop. Exit through tunnnel but before make sure to open level jump hatch");
            puzzleUI.ShowMessage("Task 3/3: Conneted the ship system hatch.");
        }
        else if (missionStep == 4)
        {
            if (nextPuzzleMarker != null)
                nextPuzzleMarker.SetActive(false);

            if (puzzleUI != null)
                puzzleUI.SetObjective("Find the green floor to jump level and to differnt part");
            puzzleUI.ShowMessage("All Task complete!");
        }
    }
}