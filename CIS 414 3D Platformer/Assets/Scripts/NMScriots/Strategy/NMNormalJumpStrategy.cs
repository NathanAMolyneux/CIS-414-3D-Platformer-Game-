using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NMNormalJumpStrategy : NMIJumpStrategy
{
    private float jumpForce;

    public NMNormalJumpStrategy(float jumpForce)
    {
        this.jumpForce = jumpForce;
    }

    public float GetJumpForce()
    {
        return jumpForce;
    }
}