using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    public class ItemManager : BaseComponent
    {
        public Action onAvailableItemsUpdated;
        
        [SerializeField]
        private ItemSpawnClamper itemSpawnClamper;
        public List<BaseItemDataSo> AvailableItems { get; private set;} = new List<BaseItemDataSo>();

        private PlayerManager playerManager;

        private void Awake()
        {
            itemSpawnClamper.Insert(this);
        }

        public override void OnEnable()
        {
            playerManager = GameManager.Instance.PlayerManager;
            playerManager.PlayerStatsManager.onLevelChanged += UpdateAvailableItems;
        }
        private void UpdateAvailableItems(int levelNum)
        {
            var allItems = AllItemsDataSo.Instance.items;
            levelNum = levelNum <= allItems.Length ? levelNum : allItems.Length;
            for (var i = 0; i < levelNum; i++)
            {
                var itemToAdd = AllItemsDataSo.Instance.items[i];
                if (AvailableItems.Contains(itemToAdd))
                    continue;
                AvailableItems.Add(itemToAdd);
            }
            onAvailableItemsUpdated?.Invoke();
        }
        
        public GameObject GetRandomItemObj()
        {
            return itemSpawnClamper.GetRandomItem();
        }
    }
}