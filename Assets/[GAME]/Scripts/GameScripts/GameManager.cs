using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.Pool;
using Scripts.BaseGameScripts.StateManagement;
using Scripts.GameScripts.InventoryManagement;
using Scripts.GameScripts.ItemCreatingManagement;
using Scripts.GameScripts.ItemManagement;
using Scripts.GameScripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class GameManager : SingletonMono<GameManager>
    {
        public bool IsGamePlaying => gameStateManager && gameStateManager.IsStateGamePlaying();

        public Camera MainMainCam => mainCam;
        public ItemManager ItemManager => itemManager;
        public PlayerManager PlayerManager => playerManager;
        public InventoryManager InventoryManager => inventoryManager;
        
        
        [SerializeField]
        private Camera mainCam;

        [SerializeField]
        private ItemManager itemManager;

        [SerializeField]
        private PlayerManager playerManager;

        [SerializeField]
        private InventoryManager inventoryManager;

     
        private GameStateManager gameStateManager;

        protected override void OnAwake()
        {
        }

        private void Start()
        {
            gameStateManager = GlobalReferences.Instance.GameStateManager;
        }
    }
}