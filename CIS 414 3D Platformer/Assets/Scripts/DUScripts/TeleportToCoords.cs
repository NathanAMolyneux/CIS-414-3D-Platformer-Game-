using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToCoords : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(36.64749f, -23.27678f, -108.2127f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetPosition;
        }
    }
}