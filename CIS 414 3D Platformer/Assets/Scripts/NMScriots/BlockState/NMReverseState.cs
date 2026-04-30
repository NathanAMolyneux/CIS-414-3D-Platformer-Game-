using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;


public class NMReverseState : NMIBlockState
{
    public void Enter(NMMovingBlock block)
    {
        Debug.Log("State: Reversing");
    }

    public void Update(NMMovingBlock block)
    {
        block.moveProgress -= block.speed * Time.deltaTime;
        block.moveProgress = Mathf.Clamp01(block.moveProgress);
        block.UpdatePosition();

        // Stop
        if (Input.GetKeyDown(KeyCode.L))
        {
            block.SetState(new NMIdleState());
        }

        // Go forward again
        if (Input.GetKeyDown(KeyCode.M))
        {
            block.SetState(new NMMovingState());
        }
    }
}