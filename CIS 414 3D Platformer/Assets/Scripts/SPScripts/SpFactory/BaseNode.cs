using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseNode : MonoBehaviour
{
    protected bool playerInside = false;

    protected virtual void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            Activate();
        }
    }

    public abstract void Activate();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}