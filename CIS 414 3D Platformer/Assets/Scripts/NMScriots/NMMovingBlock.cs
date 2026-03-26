using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMMovingBlock : MonoBehaviour
{
    //make a moving platform 
    // Start is called before the first frame update
        public Transform pointA;
        public Transform pointB;
       
         [SerializeField]private float speed = 0.2f;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.PingPong(Time.time * speed, 1));
    }
}
