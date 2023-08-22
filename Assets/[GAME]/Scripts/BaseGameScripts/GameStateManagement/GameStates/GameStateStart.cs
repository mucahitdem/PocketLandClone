using Scripts.GameScripts.GameStateManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.GameStateManagement.GameStates
{
    public class GameStateStart : BaseGameState
    {
        public override void InitState()
        {
            Time.timeScale = 1f;
        }

        public override void ExitState()
        {
        }
    }
}