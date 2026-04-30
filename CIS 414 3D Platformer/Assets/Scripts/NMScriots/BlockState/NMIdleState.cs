using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NMIdleState : NMIBlockState
{
    public void Enter(NMMovingBlock block)
    {
        Debug.Log("State: Idle");
    }

    public void Update(NMMovingBlock block)
    {
        // Press M → move forward
        if (Input.GetKeyDown(KeyCode.M))
        {
            block.SetState(new NMMovingState());
        }

        // Press R → reverse
        if (Input.GetKeyDown(KeyCode.R))
        {
            block.SetState(new NMReverseState());
        }
    }
}