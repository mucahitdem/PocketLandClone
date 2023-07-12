using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Component;
using Scripts.GameScripts.PlayerManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemManagement
{
    public class ItemManager : BaseComponent
    {
        public List<BaseItemDataSo> AvailableItems => availableItems;
        
        [SerializeField]
        private BaseItemDataSo[] allItems;
        private List<BaseItemDataSo> availableItems;

        private PlayerManager playerManager;
        
        private void Start()
        {
            playerManager = GameManager.Instance.PlayerManager;
            playerManager.PlayerStatsManager.onLevelChanged += UpdateAvailableItems;
        }


        private void UpdateAvailableItems(int levelNum)
        {
            for (int i = 0; i < levelNum; i++)
            {
                var itemToAdd = allItems[i];
                if(availableItems.Contains(itemToAdd))
                    continue;
                availableItems.Add(itemToAdd);
            }
        }
    }
}