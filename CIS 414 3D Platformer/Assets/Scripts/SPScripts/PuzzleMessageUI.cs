using UnityEngine;
using TMPro;
using System.Collections;

public class PuzzleMessageUI : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI objectiveText;

    public void ShowMessage(string message)
    {
        if (popupPanel == null || messageText == null) return;

        StopAllCoroutines();

        popupPanel.SetActive(true);
        messageText.text = message;

        StartCoroutine(HideAfterDelay());
    }

    public void SetObjective(string objective)
    {
        if (objectiveText != null)
            objectiveText.text = objective;
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(3f);

        if (popupPanel != null)
            popupPanel.SetActive(false);
    }
}