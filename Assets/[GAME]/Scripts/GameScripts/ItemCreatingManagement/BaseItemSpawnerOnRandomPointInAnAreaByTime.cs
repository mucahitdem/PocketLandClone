using Scripts.GameScripts.ItemManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public sealed class BaseItemSpawnerOnRandomPointInAnAreaByTime : GameObjectSpawnerOnRandomPointInAnAreaByTime
    {
        private ItemManager itemManager;
       
        private void Start()
        {
            itemManager = GameManager.Instance.ItemManager;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            ItemActionManager.canCreateItems += CanCreateItems;
        }
        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            ItemActionManager.canCreateItems -= CanCreateItems;
        }
        
        
        protected override GameObject GetItemToCreate()
        {
            return itemManager.GetRandomItemObj();
        }

        
        
        private void CanCreateItems(bool value)
        {
            if(value && !timer.IsRunning)
                timer.RestartTimer();
            else
                timer.StopTimer();
        }
    }
}