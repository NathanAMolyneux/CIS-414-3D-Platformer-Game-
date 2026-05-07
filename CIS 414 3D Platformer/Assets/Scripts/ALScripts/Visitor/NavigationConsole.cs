using ALScripts.Data;
using ALScripts.UI;
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

        // Update repair progress no matter what
        ShipStatus.Instance.RegisterRepair();

        // Visual feedback
        if (rend != null)
        {
            //Color repairedColor = new Color(0f, 0.8f, 1f); // cyan/blue instead of ugly green
            Color repairedColor = new Color(0f, 0.8f, 1f, 0.3f); // alpha = 0.3 (soft)

            rend.material.color = repairedColor;
            rend.material.EnableKeyword("_EMISSION");
            rend.material.SetColor("_EmissionColor", repairedColor * 1.5f);
        }

        if (GameMediator.Instance != null)
        {
            GameMediator.Instance.HandleSystemRestore("Navigation");
        }
    }
}