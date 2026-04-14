using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ALScripts.Core;
using ALScripts.State;

namespace ALScripts.Commands
{
    public class StartGameCommand : ICommand
    {
        public void Execute()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SetState(new PlayingState());
            }
        }
    }
}