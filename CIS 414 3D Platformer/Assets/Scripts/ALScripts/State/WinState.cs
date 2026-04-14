using ALScripts.Core;
using ALScripts.State;
using UnityEngine;

public class WinState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 0f;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowEndScreen("MISSION COMPLETE\nAll breaches repaired.");
        }
    }

    public void Update()
    {
    }

    public void Exit()
    {
    }
}