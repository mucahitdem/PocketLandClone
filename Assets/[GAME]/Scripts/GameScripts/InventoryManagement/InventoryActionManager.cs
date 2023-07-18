using System;
using Scripts.GameScripts.ItemManagement;

namespace Scripts.GameScripts.InventoryManagement
{
    public static class InventoryActionManager
    {
        public static Func<BaseItemDataSo,int, bool> useItem;
        public static Action<BaseItemDataSo, int> onItemCountUpdated;
    }
}