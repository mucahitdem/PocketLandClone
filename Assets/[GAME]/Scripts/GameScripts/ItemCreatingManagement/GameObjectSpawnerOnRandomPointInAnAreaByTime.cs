using System;
using Scripts.BaseGameSystemRelatedScripts.TimerManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public class GameObjectSpawnerOnRandomPointInAnAreaByTime : GameObjectSpawnerOnRandomPointInAnArea
    {
        [SerializeField]
        private Timer timer;

        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
            timer.onTimerEnded += OnTimerEnded;
        }

        protected override void UnsubscribeEvent()
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