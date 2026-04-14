using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPanel : MonoBehaviour, IShipVisitable
{
    private bool alreadyRestored = false;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void Accept(IShipVisitor visitor)
    {
        if (alreadyRestored) return;
        visitor.Visit(this);
    }

    public void RestorePower()
    {
        if (alreadyRestored) return;
        alreadyRestored = true;

        Debug.Log("Power restored.");

        // 🔥 change color
        if (rend != null)
        {
            rend.material.color = Color.green;
        }

        if (GameMediator.Instance != null)
        {
            GameMediator.Instance.HandleSystemRestore("Power");
        }
    }
}