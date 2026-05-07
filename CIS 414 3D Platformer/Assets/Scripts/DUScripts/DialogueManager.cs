using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance = null;
    public UnityEvent uEvent;
    public GameObject TriggerObject;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == TriggerObject)
        {
            Debug.Log("You Got Level Two Clearance!");

        }

    }

    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DialogueManager();
            }
            return instance;
        }
    }
}
