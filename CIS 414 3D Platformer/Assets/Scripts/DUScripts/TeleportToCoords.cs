using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToCoords : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(36f, -23f, -108f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetPosition;
        }
    }
}