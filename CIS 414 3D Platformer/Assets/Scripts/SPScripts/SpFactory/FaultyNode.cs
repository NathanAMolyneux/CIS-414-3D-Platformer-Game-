using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaultyNode : BaseNode
{
    public override void Activate()
    {
        Debug.Log("Faulty node Activate called");

        if (TunnelPuzzleProgress.Instance == null)
        {
            Debug.LogError("TunnelPuzzleProgress instance is missing.");
            return;
        }

        if (TunnelPuzzleProgress.Instance.PuzzleCompleted) return;

        Debug.Log("Wrong node! Try again.");

        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.red;
        }
        else
        {
            Debug.LogError("No child renderer found on FaultyNode.");
        }
    }
}