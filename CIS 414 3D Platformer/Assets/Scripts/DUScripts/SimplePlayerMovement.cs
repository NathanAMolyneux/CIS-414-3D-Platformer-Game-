using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
