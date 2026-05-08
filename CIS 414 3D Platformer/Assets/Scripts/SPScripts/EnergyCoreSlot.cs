using UnityEngine;

public class EnergyCoreSlot : MonoBehaviour
{
    public PuzzleMessageUI puzzleUI;

    private bool solved = false;

    public void TryPlaceCore(PlayerInventory inventory)
    {
        Debug.Log("Slot touched");

        if (solved)
        {
            if (puzzleUI != null)
                puzzleUI.ShowMessage("System already restored.");
            return;
        }

        if (inventory == null)
        {
            Debug.Log("Inventory missing");
            return;
        }

        
        if (!inventory.hasEnergyCore)
        {
            if (puzzleUI != null)
                puzzleUI.ShowMessage("You need the energy core first.");
            return;
        }

        
        solved = true;
        inventory.hasEnergyCore = false;

        Debug.Log("Energy core placed. Puzzle solved!");

        if (puzzleUI != null)
            puzzleUI.ShowMessage("Energy core installed. System restored!");

        GameFacade facade = FindObjectOfType<GameFacade>();

        if (facade != null)
        {
            facade.EnergyCoreInserted();
        }
    }
}