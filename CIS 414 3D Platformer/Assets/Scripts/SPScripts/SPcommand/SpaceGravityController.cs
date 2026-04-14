using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGravityController : MonoBehaviour
{
    [SerializeField] private bool gravityOffAtStart = true;
    [SerializeField] private float floatForce = 3f;
    [SerializeField] private float maxFloatSpeed = 2f;

    private Rigidbody[] objectsInZone;
    private bool gravityOff;

    private void Start()
    {
        gravityOff = gravityOffAtStart;
        objectsInZone = FindObjectsOfType<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!gravityOff) return;

        foreach (Rigidbody rb in objectsInZone)
        {
            if (rb == null) continue;
            if (rb.CompareTag("Player")) continue;

            if (rb.velocity.y < maxFloatSpeed)
            {
                rb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
            }
        }
    }

    public void RestoreGravity()
    {
        gravityOff = false;
        Debug.Log("Custom gravity restored.");
    }

    public void DisableGravity()
    {
        gravityOff = true;
        Debug.Log("Custom zero gravity activated.");
    }
}