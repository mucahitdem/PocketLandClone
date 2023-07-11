using System;
using Scripts.GameScripts.ItemManagement;

namespace Scripts.GameScripts.OrderManagement.Order
{
    [Serializable]
    public struct OrderTypeAndCount
    {
        public BaseItemDataSo itemDataSo;
        public int itemAmount;
    }
}