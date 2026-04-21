using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMNormalMovementStrategy : NMIMovementStrategy
{
    private float moveSpeed;

    public NMNormalMovementStrategy(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
