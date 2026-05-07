using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastIntercom : Interactable
{
    public HandleRotation handleRotation;

    protected override void Interact()
    {
        handleRotation.unRotate();
        Debug.Log("Interacted with " + gameObject.name);
    }

}
