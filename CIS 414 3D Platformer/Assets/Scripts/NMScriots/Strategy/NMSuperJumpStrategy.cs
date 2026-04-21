using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMSuperJumpStrategy : NMIJumpStrategy
{
    private float jumpForce;

    public NMSuperJumpStrategy(float jumpForce)
    {
        this.jumpForce = jumpForce;
    }

    public float GetJumpForce()
    {
        return jumpForce;
    }
}
