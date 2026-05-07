using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HangarPlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateText(string interactMessage)
    {
        interactText.text = interactMessage;
    }
}
