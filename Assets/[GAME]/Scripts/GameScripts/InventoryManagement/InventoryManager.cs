using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.GameScripts.InteractionManagement;
using Scripts.GameScripts.ItemManagement;

namespace Scripts.GameScripts.InventoryManagement
{
    public class InventoryManager : BaseComponent
    {
        public Dictionary<BaseItemDataSo, int> itemAndCount = new Dictionary<BaseItemDataSo, int>();

        private int _tempItemCount;
        private int _tempHasEnoughItem;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            InteractionActionManager.onCollectedItem += AddNewItem;
            InventoryActionManager.useItem += TryUseIfHasEnoughItem;
        }
        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            InteractionActionManager.onCollectedItem -= AddNewItem;
            InventoryActionManager.useItem -= TryUseIfHasEnoughItem;
        }
        

        private int CurrentItemCount(BaseItemDataSo itemDataSo)
        {
            if (itemAndCount.TryGetValue(itemDataSo, out int itemCount))
            {
                return itemCount;
            }

            return 0;
        }
        private void AddNewItem(BaseItemDataSo itemDataSo)
        {
            if (itemAndCount.TryGetValue(itemDataSo, out _tempItemCount))
            {
                _tempItemCount++;
                itemAndCount[itemDataSo] = _tempItemCount;
                InventoryActionManager.onItemCountUpdated?.Invoke(itemDataSo, _tempItemCount);
            }
            else
            {
                itemAndCount.Add(itemDataSo, 1);
                InventoryActionManager.onItemCountUpdated?.Invoke(itemDataSo, 1);
            }
        }

        private bool TryUseIfHasEnoughItem(BaseItemDataSo itemDataSo, int itemCountToUse)
        {
            if (itemAndCount.TryGetValue(itemDataSo, out _tempHasEnoughItem))
            {
                if (_tempHasEnoughItem >= itemCountToUse)
                {
                    _tempHasEnoughItem -= itemCountToUse;
                    itemAndCount[itemDataSo] = _tempHasEnoughItem;
                    InventoryActionManager.onItemCountUpdated?.Invoke(itemDataSo, _tempHasEnoughItem);

                    return true;
                }
            }
            
            return false;
        }
    }
}