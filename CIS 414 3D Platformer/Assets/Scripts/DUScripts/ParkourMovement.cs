using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourMovement : MonoBehaviour
{
    public float speed = 5f;
    private bool isUp = false;
    public Transform target;
    //private Vector3 targetPosition;




    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
        if (isUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
    }

    public void MoveParkour()
    {
        isUp = true;
    }
}
