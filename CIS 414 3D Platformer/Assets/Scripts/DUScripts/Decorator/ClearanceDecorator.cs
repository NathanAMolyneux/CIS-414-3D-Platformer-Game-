using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClearanceDecorator : IDecorator
{
    private IDecorator decorator;

    public ClearanceDecorator(IDecorator decorator)
    {
        this.decorator = decorator;
    }

    public virtual string upClearance()
    {
        return decorator.upClearance();
    }
}
