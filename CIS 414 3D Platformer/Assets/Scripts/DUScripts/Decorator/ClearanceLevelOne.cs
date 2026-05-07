using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearanceLevelOne : ClearanceDecorator
{
    public ClearanceLevelOne(IDecorator decorator) : base(decorator)
    {

    }

    public override string upClearance()
    {
        return base.upClearance() + "One";
    }
}
