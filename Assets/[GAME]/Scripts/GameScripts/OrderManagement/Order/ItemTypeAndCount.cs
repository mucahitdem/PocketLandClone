using System;
using Scripts.GameScripts.ItemManagement;

namespace Scripts.GameScripts.OrderManagement.Order
{
    [Serializable]
    public struct ItemTypeAndCount
    {
        public BaseItemDataSo itemDataSo;
        public int itemAmount;

        public ItemTypeAndCount(BaseItemDataSo itemDataSo, int itemAmount)
        {
            this.itemDataSo = itemDataSo;
            this.itemAmount = itemAmount;
        }
    }
}