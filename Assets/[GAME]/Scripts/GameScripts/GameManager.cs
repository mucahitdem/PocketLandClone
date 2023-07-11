using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.State;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class GameManager : SingletonMono<GameManager>
    {
        public bool IsGamePlaying => gameStateManager && gameStateManager.IsStateGamePlaying();
        public Camera MainCam => cam;


        [SerializeField]
        private Camera cam;

        private GameStateManager gameStateManager;

        protected override void OnAwake()
        {
            
        }
        
        private void Start()
        {
            gameStateManager = GlobalReferences.Instance.gameStateManager;
        }


      
    }
}