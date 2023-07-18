using Scripts.BaseGameScripts.Helper;
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

        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
            ItemActionManager.canCreateItems += CanCreateItems;
        }
        
        protected override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            ItemActionManager.canCreateItems -= CanCreateItems;
        }
        
        private void CanCreateItems(bool value)
        {
            if(value && !timer.IsRunning)
                timer.RestartTimer();
            else
                timer.StopTimer();
        }

        protected override GameObject GetItemToCreate()
        {
            return itemManager.GetRandomItemObj();
        }
    }
}