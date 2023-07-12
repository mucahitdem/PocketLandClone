using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.Managers;
using Scripts.BaseGameScripts.Pool;
using Scripts.BaseGameScripts.State;
using Scripts.BaseGameScripts.UI;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts
{
    public class GlobalReferences : SingletonMono<GlobalReferences>
    {
        public UiManager UiManager => uiManager;
        public LevelManager LevelManager => levelManager;
        public GameStateManager GameStateManager => gameStateManager;


        [SerializeField]
        private UiManager uiManager;
        [SerializeField]
        private LevelManager levelManager;
        [SerializeField]
        private GameStateManager gameStateManager;

        protected override void OnAwake()
        {
        }
    }
}