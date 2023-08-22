using Scripts.BaseGameScripts.GameStateManagement;
using Scripts.BaseGameScripts.GameStateManagement.GameStates;
using Scripts.BaseGameScripts.StateManagement._Interface;
using Scripts.GameScripts.GameStateManagement.GameStates;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.GameStateManagement
{
    public class GameStateManager : MonoBehaviour
    {
        [ShowInInspector]
        [ReadOnly]
        private IGameState _currentState;

        private void Start()
        {
            SetState(Defs.GAME_STATE_START);
        }

        public void SetState(string newStateId)
        {
            var newGameState = AllGameStateDataSo.Instance.GetStateWithId(newStateId);
            
            _currentState?.ExitState();

            _currentState = newGameState;
            _currentState.InitState();
            OnStateUpdate();
        }
      

        private void OnStateUpdate()
        {
            RaiseEvents();
        }
        private void RaiseEvents()
        {
            if (IsStateGameStart())
                GameStateActionManager.onStartState?.Invoke();

            if (IsStateGamePlaying())
                GameStateActionManager.onPlayingState?.Invoke();

            if (IsStateGameLose())
                GameStateActionManager.onLoseState?.Invoke();

            if (IsStateGameWin())
                GameStateActionManager.onWinState?.Invoke();
        }
        private bool IsStateGameStart()
        {
            return ReferenceEquals(_currentState, typeof(GameStateStart));
        }
        private bool IsStateGamePlaying()
        {
            return ReferenceEquals(_currentState, typeof(GameStatePlaying));
        }
        private bool IsStateGameLose()
        {
            return ReferenceEquals(_currentState, typeof(GameStateLose));
        }
        private bool IsStateGameWin()
        {
            return ReferenceEquals(_currentState, typeof(GameStateWin));
        }

    }
}