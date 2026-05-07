using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRotation : MonoBehaviour
{

    public float speed = 0f;
    public float rotateBack = 0f;
    private Quaternion targetRotation;
    private Quaternion backRotation;
    private bool shouldRotate = false;


    void Start()
    {
        targetRotation = Quaternion.Euler(0f, 0f, -90f);
        backRotation = Quaternion.Euler(0f, 0f, 0f);

    }
    void Update()
    {
        if(shouldRotate == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
        if(shouldRotate == false)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, backRotation, rotateBack * Time.deltaTime);
        }

    }

    public void Rotate()
    {
        shouldRotate = true;
    }

    public void unRotate()
    {
        shouldRotate = false;
    }


}
