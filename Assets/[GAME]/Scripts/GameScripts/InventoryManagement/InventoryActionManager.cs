using System;
using System.Collections.Generic;
using Scripts.GameScripts.ItemManagement;

namespace Scripts.GameScripts.InventoryManagement
{
    public static class InventoryActionManager
    {
        public static Func<Dictionary<BaseItemDataSo, int>> getItemsAndCount;
        public static Func<BaseItemDataSo,int, bool> useItem;
        public static Action<BaseItemDataSo, int> onItemCountUpdated;
    }
}