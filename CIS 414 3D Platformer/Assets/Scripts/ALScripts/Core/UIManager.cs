using TMPro;
using UnityEngine;

namespace ALScripts.Core
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [Header("Intro UI")]
        [SerializeField] private GameObject introPanel;
        [SerializeField] private TextMeshProUGUI introText;

        [Header("Gameplay UI")]
        [SerializeField] private GameObject hudPanel;
        [SerializeField] private GameObject objectivePanel;

        [Header("End UI")]
        [SerializeField] private GameObject endPanel;
        [SerializeField] private TextMeshProUGUI endText;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public void ShowIntro(string message)
        {
            if (introPanel != null) introPanel.SetActive(true);
            if (introText != null) introText.text = message;

            if (hudPanel != null) hudPanel.SetActive(false);
            if (objectivePanel != null) objectivePanel.SetActive(false);
            if (endPanel != null) endPanel.SetActive(false);
        }

        public void HideIntro()
        {
            if (introPanel != null) introPanel.SetActive(false);
        }

        public void ShowGameplayUI()
        {
            if (hudPanel != null) hudPanel.SetActive(true);
            if (objectivePanel != null) objectivePanel.SetActive(true);
        }

        public void ShowEndScreen(string message)
        {
            if (endPanel != null) endPanel.SetActive(true);
            if (endText != null) endText.text = message;
        }
    }
}