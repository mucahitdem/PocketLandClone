using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.TimerManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public class GameObjectSpawnerByTimer : BaseGameObjectSpawner
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

        protected virtual void OnTimerEnded()
        {
            CreateObject();
        }

        protected override void CreateObject()
        {
        }

        protected override GameObject GetItemToCreate()
        {
            return itemToCreate;
        }
    }
}