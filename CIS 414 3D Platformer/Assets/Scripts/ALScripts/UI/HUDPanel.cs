using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
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
                shipConditionText.text = $"Ship Condition: {ShipStatus.Instance.ShipCondition:0}%";
            }

            if (shipSpeedText != null)
            {
                shipSpeedText.text = $"Speed: {ShipStatus.Instance.ShipSpeed:0.0} km/s";
            }
        }
    }
}