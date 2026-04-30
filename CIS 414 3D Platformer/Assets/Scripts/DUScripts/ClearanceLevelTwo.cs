using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearanceLevelTwo : ClearanceDecorator
{
    public override int getClearance()
    {
        return 2;
    }
}
