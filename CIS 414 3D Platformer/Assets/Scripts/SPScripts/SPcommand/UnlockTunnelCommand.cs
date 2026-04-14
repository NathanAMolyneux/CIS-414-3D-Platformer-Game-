using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UnlockTunnelCommand : IActionCommand
{
    private NewSceneLoader sceneLoader;

    public UnlockTunnelCommand(NewSceneLoader loader)
    {
        sceneLoader = loader;
    }

    public void Execute()
    {
        if (sceneLoader != null)
        {
            sceneLoader.EnableLoading();
            Debug.Log("My command executed: tunnel unlocked.");
        }
    }
}