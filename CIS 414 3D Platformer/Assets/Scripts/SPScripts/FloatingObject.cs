using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FloatingObject: MonoBehaviour
{
    [SerializeField] private float floatForce = 5f;
    [SerializeField] private float swayForce = 2f;
    [SerializeField] private float maxVelocity = 2f;

    private Rigidbody rb;
    private bool floatingActive = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; 
    }

    private void FixedUpdate()
    {
        if (!floatingActive) return;

        // putting the upward force
        if (rb.velocity.y < maxVelocity)
        {
            rb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
        }

        //  making a slight random drift
        Vector3 drift = new Vector3(
            Mathf.Sin(Time.time) * swayForce,
            0f,
            Mathf.Cos(Time.time) * swayForce
        );

        rb.AddForce(drift, ForceMode.Acceleration);
    }

    public void StopFloating()
    {
        floatingActive = false;
        rb.useGravity = true;
    }
}