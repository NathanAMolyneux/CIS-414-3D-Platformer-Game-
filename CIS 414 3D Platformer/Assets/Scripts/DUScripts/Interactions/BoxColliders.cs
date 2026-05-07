using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliders : MonoBehaviour
{
    [SerializeField] private BoxCollider[] colliders;

    public void ChangeColliders(bool enabled)
    {
        foreach (BoxCollider col in colliders)
        {
            col.enabled = enabled;
        }
    }
}
