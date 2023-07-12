using System;
using Scripts.GameScripts.ItemManagement;

namespace Scripts.GameScripts.OrderManagement.Order
{
    [Serializable]
    public struct ItemTypeAndCount
    {
        public BaseItemDataSo item;
        public int itemAmount;

        public ItemTypeAndCount(BaseItemDataSo item, int itemAmount)
        {
            this.item = item;
            this.itemAmount = itemAmount;
        }
    }
}