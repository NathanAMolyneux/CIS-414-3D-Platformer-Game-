using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ALScripts.Core;

namespace ALScripts.State
{
    public class IntroState : IGameState
    {
        public void Enter()
        {
            if (UIManager.Instance != null)
            {
                UIManager.Instance.ShowIntro(
                    "WARNING: Breach detected in one of the ship sections.\n" +
                    "You must repair the system before the ship collapses.\n\n" +
                    "Press ENTER to start"
                );
            }

            Time.timeScale = 0f;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                GameManager.Instance.SetState(new PlayingState());
            }
        }

        public void Exit()
        {
            if (UIManager.Instance != null)
            {
                UIManager.Instance.HideIntro();
            }

            Time.timeScale = 1f;
        }
    }
}