using TMPro;
using UnityEngine;
using ALScripts.Data;

namespace ALScripts.UI
{
    public class HUDPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI shipConditionText;
        [SerializeField] private TextMeshProUGUI shipSpeedText;

        private void OnEnable()
        {
            ShipStatus.Instance.OnStatusChanged += UpdateUI;
            UpdateUI();
        }

        private void OnDisable()
        {
            ShipStatus.Instance.OnStatusChanged -= UpdateUI;
        }

        private void UpdateUI()
        {
            if (shipConditionText != null)
            {
                shipConditionText.text =
                    $"SHIP CONDITION: {ShipStatus.Instance.ShipCondition:0}%";
            }

            if (shipSpeedText != null)
            {
                shipSpeedText.text =
                    $"SHIP SPEED: {ShipStatus.Instance.ShipSpeed:0.0} km/s";
            }
        }
    }
}