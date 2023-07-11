using Scripts.BaseGameSystemRelatedScripts;
using Scripts.BaseGameSystemRelatedScripts.TimerManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public class BaseItemCreatorByTimer : BaseItemCreator
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

        protected override void CreateItem()
        {
        }

        protected virtual void OnTimerEnded()
        {
            CreateItem();
        }
    }
}