using Scripts.BaseGameScripts.TimerManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public class GameObjectSpawnerOnRandomPointInAnAreaByTime : GameObjectSpawnerOnRandomPointInAnArea
    {
        [SerializeField]
        protected Timer timer;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            timer.onTimerEnded += OnTimerEnded;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            timer.onTimerEnded -= OnTimerEnded;
        }

        private void OnTimerEnded()
        {
            CreateObject();
        }
    }
}