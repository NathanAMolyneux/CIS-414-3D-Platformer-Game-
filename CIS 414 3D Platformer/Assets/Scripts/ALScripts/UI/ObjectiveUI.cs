using TMPro;
using UnityEngine;
using ALScripts.Data;

namespace ALScripts.UI
{
    public class ObjectiveUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI objectiveText;
        [SerializeField] private TextMeshProUGUI statusText;

        private void OnEnable()
        {
            if (ShipStatus.Instance != null)
            {
                ShipStatus.Instance.OnStatusChanged += UpdateUI;
                UpdateUI();
            }
        }

        private void OnDisable()
        {
            if (ShipStatus.Instance != null)
                ShipStatus.Instance.OnStatusChanged -= UpdateUI;
        }

        private void UpdateUI()
        {
            int repaired = ShipStatus.Instance.RepairedBreaches;
            int total = ShipStatus.Instance.TotalBreaches;

            if (objectiveText != null)
            {
                if (repaired == 0)
                {
                    objectiveText.text = "Task: Restore Navigation Console";
                }
                else if (repaired == 1)
                {
                    objectiveText.text = "Task: Stabilize Power Panel";
                }
                else if (repaired == 2)
                {
                    objectiveText.text = "Task: Repair Oxygen System";
                }
                else
                {
                    objectiveText.text = "Task Return to Control Room";
                }
            }

            if (statusText != null)
            {
                if (repaired < total)
                {
                    statusText.text = $"Systems repaired: {repaired}/{total}";
                }
                else
                {
                    statusText.text = "Status: All systems stable";
                }
            }
        }
    }
}