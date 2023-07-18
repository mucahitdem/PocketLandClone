using System;
using Scripts.GameScripts.ItemManagement;

namespace Scripts.GameScripts.InteractionManagement
{
    public static class InteractionActionManager
    {
        public static Action<BaseItemDataSo> onCollectedItem;
    }
}