using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearanceLevelOne : ClearanceDecorator
{
    public override int getClearance()
    {
        return 1;
    }
}
