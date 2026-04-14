using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationConsole : MonoBehaviour, IShipVisitable
{
    private bool alreadyRestored = false;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponentInChildren<Renderer>();
    }

    public void Accept(IShipVisitor visitor)
    {
        if (alreadyRestored) return;
        visitor.Visit(this);
    }

    public void RestoreNavigation()
    {
        if (alreadyRestored) return;

        alreadyRestored = true;

        Debug.Log("Navigation restored.");

        if (rend != null)
        {
            rend.material.color = Color.green;

            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", Color.green * 2f);
        }

        if (GameMediator.Instance != null)
        {
            GameMediator.Instance.HandleSystemRestore("Navigation");
        }
    }
}