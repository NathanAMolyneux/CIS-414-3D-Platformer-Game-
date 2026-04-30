using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClearanceDecorator : IDecorator
{
    public abstract int getClearance();
}
