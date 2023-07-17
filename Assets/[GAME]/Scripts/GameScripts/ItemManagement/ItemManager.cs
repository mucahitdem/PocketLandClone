using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.PlayerManagement;

namespace Scripts.GameScripts.ItemManagement
{
    public class ItemManager : BaseComponent
    {
        private PlayerManager playerManager;
        public List<BaseItemDataSo> AvailableItems { get; }

        private void Start()
        {
            playerManager = GameManager.Instance.PlayerManager;
            playerManager.PlayerStatsManager.onLevelChanged += UpdateAvailableItems;
        }

        private void UpdateAvailableItems(int levelNum)
        {
            for (var i = 0; i < levelNum; i++)
            {
                var itemToAdd = AllItemsDataSo.Instance.items[i];
                if (AvailableItems.Contains(itemToAdd))
                    continue;
                AvailableItems.Add(itemToAdd);
            }
        }
    }
}