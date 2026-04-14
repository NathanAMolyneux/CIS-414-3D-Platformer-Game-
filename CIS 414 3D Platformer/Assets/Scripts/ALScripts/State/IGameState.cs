using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ALScripts.State
{
    public interface IGameState
    {
        void Enter();
        void Update();
        void Exit();
    }
}