using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.GameStateManagement;
using Scripts.GameScripts.InventoryManagement;
using Scripts.GameScripts.ItemManagement;
using Scripts.GameScripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class GameManager : SingletonMono<GameManager>
    {
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
    }
}