using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    public class ItemManager : BaseComponent
    {
        private PlayerManager playerManager;
        [field: SerializeField]
        public List<BaseItemDataSo> AvailableItems { get;} = new List<BaseItemDataSo>();

        public override void OnEnable()
        {
            playerManager = GameManager.Instance.PlayerManager;
            playerManager.PlayerStatsManager.onLevelChanged += UpdateAvailableItems;
        }
        private void UpdateAvailableItems(int levelNum)
        {
            DebugHelper.LogRed("SET AVAILABLE ITEMS");
            for (var i = 0; i < levelNum; i++)
            {
                var itemToAdd = AllItemsDataSo.Instance.items[i];
                if (AvailableItems.Contains(itemToAdd))
                    continue;
                AvailableItems.Add(itemToAdd);
            }
        }
        public BaseItemDataSo GetRandomItemDataSo()
        {
            return AvailableItems[Random.Range(0, AvailableItems.Count)];
        }
    }
}