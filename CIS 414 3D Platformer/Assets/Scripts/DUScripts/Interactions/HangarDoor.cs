using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HangarDoor : Interactable
{



    protected override void Interact()
    {
        SceneManager.LoadScene("HubWorld");
        Debug.Log("Interacted with " + gameObject.name);
    }
}
