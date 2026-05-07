using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearanceModule : Interactable
{
    public HandleRotation handleRotation;
    public BoxColliders boxColliders;

    protected override void Interact()
    {
        handleRotation.Rotate();
        boxColliders.ChangeColliders(false);
        Debug.Log("Interacted with " + gameObject.name);
    }
}
