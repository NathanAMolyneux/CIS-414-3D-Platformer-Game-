using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMFastMovementStrategy : NMIMovementStrategy
{
    private float moveSpeed;
    public NMFastMovementStrategy(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}