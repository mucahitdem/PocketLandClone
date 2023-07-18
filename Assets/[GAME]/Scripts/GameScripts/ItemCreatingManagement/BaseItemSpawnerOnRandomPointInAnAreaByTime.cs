using System;
using Scripts.GameScripts.ItemManagement;
using UnityEngine;

namespace Scripts.GameScripts.ItemCreatingManagement
{
    public class BaseItemSpawnerOnRandomPointInAnAreaByTime : GameObjectSpawnerOnRandomPointInAnAreaByTime
    {
        protected override GameObject ItemToCreate => itemManager.GetRandomItemDataSo().baseItemData.itemPrefab.Go;

        private ItemManager itemManager;


        protected virtual void Start()
        {
            itemManager = GameManager.Instance.ItemManager;
        }
    }
}