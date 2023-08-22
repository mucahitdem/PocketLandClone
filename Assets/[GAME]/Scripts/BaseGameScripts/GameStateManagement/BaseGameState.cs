using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.StateManagement._Interface;
using UnityEngine;

namespace Scripts.GameScripts.GameStateManagement
{
    public abstract class BaseGameState : BaseComponent, IGameState
    {
        public string StateId => stateId;
        
        [SerializeField]
        private string stateId;
        
        public abstract void InitState();
        public abstract void ExitState();
    }
}