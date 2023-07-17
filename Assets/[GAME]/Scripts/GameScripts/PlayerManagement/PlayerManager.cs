using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.InteractionManagement;
using Scripts.GameScripts.MovementManagement;
using Scripts.GameScripts.StatsManagement.PlayerStatsManagement;
using UnityEngine;

namespace Scripts.GameScripts.PlayerManagement
{
    public sealed class PlayerManager : BaseComponent
    {
        [SerializeField]
        private BaseMovementManager baseMovementManager;


        [SerializeField]
        private PlayerInteractionManager playerInteractionManager;

        [SerializeField]
        private PlayerStatsManager playerStatsManager;

        public int Level => PlayerStatsManager.Level;

        public BaseMovementManager BaseMovementManager => baseMovementManager;
        public PlayerStatsManager PlayerStatsManager => playerStatsManager;

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