using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearanceLevelThree : ClearanceDecorator
{
    public override int getClearance()
    {
        return 3;
    }
}