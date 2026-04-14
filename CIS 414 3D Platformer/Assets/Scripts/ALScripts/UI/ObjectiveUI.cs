using System.Collections;
using System.Collections.Generic;
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
            ShipStatus.Instance.OnStatusChanged += UpdateUI;
            UpdateUI();
        }

        private void OnDisable()
        {
            ShipStatus.Instance.OnStatusChanged -= UpdateUI;
        }

        private void UpdateUI()
        {
            if (objectiveText != null)
            {
                objectiveText.text =
                    $"Breaches Fixed: {ShipStatus.Instance.RepairedBreaches}/{ShipStatus.Instance.TotalBreaches}";
            }

            if (statusText != null)
            {
                if (ShipStatus.Instance.RepairedBreaches < ShipStatus.Instance.TotalBreaches)
                {
                    statusText.text = "Status: Emergency repair in progress";
                }
                else
                {
                    statusText.text = "Status: All systems stable";
                }
            }
        }
    }
}