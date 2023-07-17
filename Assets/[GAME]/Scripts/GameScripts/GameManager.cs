using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.StateManagement;
using Scripts.GameScripts.ItemManagement;
using Scripts.GameScripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class GameManager : SingletonMono<GameManager>
    {
        [SerializeField]
        private Camera cam;

        private GameStateManager gameStateManager;

        [SerializeField]
        private ItemManager itemManager;

        [SerializeField]
        private PlayerManager playerManager;

        public bool IsGamePlaying => gameStateManager && gameStateManager.IsStateGamePlaying();
        public Camera MainCam => cam;
        public PlayerManager PlayerManager => playerManager;

        public ItemManager ItemManager => itemManager;

        protected override void OnAwake()
        {
        }

        private void Start()
        {
            gameStateManager = GlobalReferences.Instance.GameStateManager;
        }
    }
}