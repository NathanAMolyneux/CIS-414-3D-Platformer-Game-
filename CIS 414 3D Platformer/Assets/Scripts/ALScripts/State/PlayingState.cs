using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ALScripts.Core;

namespace ALScripts.State
{
    public class PlayingState : IGameState
    {
        public void Enter()
        {
            if (UIManager.Instance != null)
            {
                UIManager.Instance.ShowGameplayUI();
            }
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}
