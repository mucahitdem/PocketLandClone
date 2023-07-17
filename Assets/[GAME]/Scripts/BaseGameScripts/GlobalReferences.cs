using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.Managers;
using Scripts.BaseGameScripts.StateManagement;
using Scripts.BaseGameScripts.UI;
using UnityEngine;

namespace Scripts.BaseGameScripts
{
    public class GlobalReferences : SingletonMono<GlobalReferences>
    {
        [SerializeField]
        private GameStateManager gameStateManager;

        [SerializeField]
        private LevelManager levelManager;


        [SerializeField]
        private UiManager uiManager;

        public UiManager UiManager => uiManager;
        public LevelManager LevelManager => levelManager;
        public GameStateManager GameStateManager => gameStateManager;

        protected override void OnAwake()
        {
        }
    }
}