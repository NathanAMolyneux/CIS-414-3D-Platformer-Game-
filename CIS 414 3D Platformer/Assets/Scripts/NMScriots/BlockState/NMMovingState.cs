using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class NMMovingState : NMIBlockState
{
    public void Enter(NMMovingBlock block)
    {
        Debug.Log("State: Moving Forward");
    }

    public void Update(NMMovingBlock block)
    {
        block.moveProgress += block.speed * Time.deltaTime;
        block.moveProgress = Mathf.Clamp01(block.moveProgress);
        block.UpdatePosition();

        // Stop
        if (Input.GetKeyDown(KeyCode.L))
        {
            block.SetState(new NMIdleState());
        }

        // Reverse direction
        if (Input.GetKeyDown(KeyCode.R))
        {
            block.SetState(new NMReverseState());
        }
    }
}