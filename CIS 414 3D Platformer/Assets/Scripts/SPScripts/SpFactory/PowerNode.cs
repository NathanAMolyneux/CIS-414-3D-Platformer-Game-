using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerNode : BaseNode
{
    private bool activated = false;

    public override void Activate()
    {
        Debug.Log(gameObject.name + " Activate called");

        if (activated) return;

        if (TunnelPuzzleProgress.Instance == null)
        {
            Debug.LogError("TunnelPuzzleProgress instance is missing.");
            return;
        }

        if (TunnelPuzzleProgress.Instance.PuzzleCompleted) return;

        activated = true;

        Debug.Log("Correct node activated!");
        MissionManager missionManager = FindObjectOfType<MissionManager>();

        //if (missionManager != null)
        //{
        //    missionManager.SetMissionStep(1);
        //}

        Renderer rend = GetComponentInChildren<Renderer>();
        if (rend != null)
        {
            rend.material.color = Color.green;
        }
        else
        {
            Debug.LogError("No child renderer found on " + gameObject.name);
        }

        TunnelPuzzleProgress.Instance.RegisterCorrectNode();
    }
}