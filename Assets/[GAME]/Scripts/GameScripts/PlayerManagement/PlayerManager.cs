using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.InteractionManagement;
using Scripts.GameScripts.InventoryManagement;
using Scripts.GameScripts.MovementManagement;
using Scripts.GameScripts.StatsManagement.PlayerStatsManagement;
using UnityEngine;

namespace Scripts.GameScripts.PlayerManagement
{
    public sealed class PlayerManager : BaseComponent
    {
        public int Level => PlayerStatsManager.Level;

        public BaseMovementManager BaseMovementManager => baseMovementManager;
        public PlayerStatsManager PlayerStatsManager => playerStatsManager;
        
        
        [SerializeField]
        private BaseMovementManager baseMovementManager;
        
        [SerializeField]
        private PlayerStatsManager playerStatsManager;

        [SerializeField]
        private PlayerInteractionManager playerInteractionManager;
        
        [SerializeField]
        private InventoryManager inventoryManager;

        
        private void Awake()
        {
            baseMovementManager.Insert(this);
        }

        private void Update()
        {
            baseMovementManager.OnUpdate();
        }

        private void FixedUpdate()
        {
            baseMovementManager.OnFixedUpdate();
        }
    }
}