using Scripts.BaseGameSystemRelatedScripts.TimerManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public class GameObjectSpawnerByTimer : BaseGameObjectSpawner
    {
        [SerializeField]
        protected Timer timer;

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