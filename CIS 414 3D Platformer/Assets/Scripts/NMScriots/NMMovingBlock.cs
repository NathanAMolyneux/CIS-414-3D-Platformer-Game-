using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class NMMovingBlock : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    [SerializeField] public float speed = 0.2f;

    [HideInInspector] public float moveProgress = 0f;

    private NMIBlockState currentState;

    void Start()
    {
        SetState(new NMIdleState());
        UpdatePosition();
    }

    void Update()
    {
        currentState.Update(this);
    }

    public void SetState(NMIBlockState newState)
    {
        currentState = newState;
        currentState.Enter(this);
    }

    public void UpdatePosition()
    {
        transform.position = Vector3.Lerp(pointA.position, pointB.position, moveProgress);
    }
}