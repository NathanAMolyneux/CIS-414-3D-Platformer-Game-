using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NMWaypointMover : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    void Start()
    {
        // Start object at point A
        transform.position = pointA.position;
    }

    void Update()
    {
        // Move toward point B
        transform.position = Vector3.MoveTowards(
            transform.position,
            pointB.position,
            speed * Time.deltaTime
        );

        // Check if reached point B
        if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}