using UnityEngine;

namespace ALScripts.Commands
{
    public class RepairCommand : ICommand
    {
        public void Execute()
        {
            if (BreachMissionController.Instance != null)
            {
                BreachMissionController.Instance.CompleteRepair();
            }
            else
            {
                Debug.LogWarning("RepairCommand: No BreachMissionController found.");
            }
        }
    }
}