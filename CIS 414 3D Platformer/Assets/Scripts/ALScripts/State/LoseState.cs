using ALScripts.Core;
using ALScripts.State;
using UnityEngine;

public class LoseState : IGameState
{
    public void Enter()
    {
        Time.timeScale = 0f;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowEndScreen("MISSION FAILED\nShip condition reached critical level.");
        }
    }

    public void Update()
    {
    }

    public void Exit()
    {
    }
}