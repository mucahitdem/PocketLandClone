using System.Collections;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.InteractionManagement;
using Scripts.GameScripts.MovementManagement;
using Scripts.GameScripts.StatsManagement.PlayerStatsManagement;
using UnityEngine;

namespace Scripts.GameScripts.PlayerManagement
{
    public sealed class PlayerManager : BaseComponent
    { 
        public BaseMovementManager BaseMovementManager => baseMovementManager;
        public PlayerStatsManager PlayerStatsManager => playerStatsManager;

        [SerializeField]
        private BaseMovementManager baseMovementManager;

        [SerializeField]
        private PlayerStatsManager playerStatsManager;
        

        [SerializeField]
        private PlayerInteractionManager playerInteractionManager;

        private void Awake()
        {
            baseMovementManager.Insert(this);
            playerInteractionManager.onXpCollected += OnXpCollected;
        }
        
        private void Update()
        {
            baseMovementManager.OnUpdate();
        }
        
        private void FixedUpdate()
        { 
            baseMovementManager.OnFixedUpdate();
        }
        
        
        private void OnXpCollected(float xpCollected)
        {
            playerStatsManager.CollectXp(xpCollected);
        }
    }
}