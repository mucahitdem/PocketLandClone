using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.State.GameStates;
using Scripts.State._Interface;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.State
{
    public class GameStateManager : MonoBehaviour
    {
        [ShowInInspector]
        [ReadOnly]
        private IGameState _currentState;

        [Title("Private Variables")]
        private bool _firstState;

        private int _indexInList;
        public List<IGameState> states = new List<IGameState>();

        private void Awake()
        {
            AddStates();
        }

        private void AddStates()
        {
            var subClasses = AssemblyManager.GetSubClassesOfType(typeof(GameState));

            for (var i = 0; i < subClasses.Count; i++)
            {
                var currentType = subClasses[i];

                var stateBehaviour = (IGameState) gameObject.AddComponent(currentType);
                states.Add(stateBehaviour);

                if (!_firstState)
                {
                    _firstState = true;
                    _currentState = stateBehaviour;
                }
            }
        }


        public bool IsStateGamePlaying()
        {
            return _currentState == ((IGameState)typeof(GameState02_0Playing));
        }

        /// <summary>
        ///     Go to next state from list of states
        /// </summary>
        public void NextState()
        {
            IncreaseIndex();

            _currentState = GetStateWithIndex();
            _currentState.InitState();
        }

        /// <summary>
        ///     Sub level is number after "_" in the Game State name.
        ///     For Example GameState_03_0. Here "0" after "_" represent sub level
        /// </summary>
        /// <param name="subLevel"></param>
        public void NextState(int subLevel)
        {
        }

        /// <summary>
        ///     If you don't know sub level, see "NextState(int subLevel)" description first.
        ///     "isSucceeded" represent win/lose situation of current state. If sub level is "0", it is fail. Else if it is "1", it
        ///     is success
        /// </summary>
        /// <param name="newGameState"></param>
        public void NextState(IGameState newGameState)
        {
            _currentState = FindState(newGameState);
            _currentState.InitState();
        }
        
        public void NextState(bool isSucceed)
        {
            _currentState = FindState(isSucceed);
            _currentState.InitState();
        }
        private void IncreaseIndex()
        {
            _indexInList++;
        }
        private IGameState GetStateWithIndex()
        {
            try
            {
                return states[_indexInList];
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private IGameState FindState(IGameState gameState)
        {
            for (int i = 0; i < states.Count; i++)
            {
                var currentState = states[i];
                if (currentState == gameState)
                {
                    return currentState;
                }
            }

            return null;
        }
        private IGameState FindState(bool isSucceed)
        {
            for (int i = 0; i < states.Count; i++)
            {
                var currentState = states[i];
                if (isSucceed)
                {
                    if (currentState.GetType() == typeof(GameState03_1Win))
                    {
                        DebugHelper.LogGreen(" WIN LEVEL ");
                        return currentState;
                    }
                }
                else
                {
                    if ((Type) currentState == typeof(GameState03_0Lose))
                    {
                        DebugHelper.LogGreen(" LOSE LEVEL ");
                        return currentState;
                    }
                }
            }
            return null;
        }
    }
}