using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairVisitor : IShipVisitor
{
    public void Visit(PowerPanel panel)
    {
        panel.RestorePower();
    }

    public void Visit(OxygenPanel panel)
    {
        panel.RestoreOxygen();
    }

    public void Visit(NavigationConsole console)
    {
        console.RestoreNavigation();
    }
}