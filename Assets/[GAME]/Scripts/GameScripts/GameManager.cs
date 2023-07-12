using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.State;
using Scripts.GameScripts.ItemManagement;
using Scripts.GameScripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class GameManager : SingletonMono<GameManager>
    {
        public bool IsGamePlaying => gameStateManager && gameStateManager.IsStateGamePlaying();
        public Camera MainCam => cam;
        public PlayerManager PlayerManager => playerManager;

        public ItemManager ItemManager => itemManager;
        
        
        
        [SerializeField]
        private Camera cam;

        [SerializeField]
        private PlayerManager playerManager;

        [SerializeField]
        private ItemManager itemManager;
        
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