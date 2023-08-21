using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManager;
using Scripts.GameScripts.InteractionManagement;
using Scripts.GameScripts.OrderManagement.Order;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.GameScripts.ItemManagement
{
    public class ItemSpawnClamper : BaseComponent
    {
        [SerializeField]
        private ItemTypeAndCount[] objAndCountForClamp;
        
        private Dictionary<BaseItemDataSo, int> createdObjAndCount = new Dictionary<BaseItemDataSo, int>();
        [SerializeField]
        [ReadOnly]
        private List<BaseItemDataSo> objClamped = new List<BaseItemDataSo>();
        [SerializeField]
        [ReadOnly]
        private List<BaseItemDataSo> objCanCreatable = new List<BaseItemDataSo>();
        private int _tempCount;

        private ItemManager itemManager;
        
        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            itemManager = (ItemManager) baseComponent;
            itemManager.onAvailableItemsUpdated += OnAvailableItemsUpdated;
        }

        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
            InteractionActionManager.onCollectedItem += OnCollectedItemFromGround;
        }
        protected override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();            
            InteractionActionManager.onCollectedItem -= OnCollectedItemFromGround;
        }

        
        public GameObject GetRandomItem()
        {
            if (IsAllItemsClamped())
            {
                ItemActionManager.canCreateItems?.Invoke(false);
                return null;
            }
            
            var createdDataSo = GetItemToCreate();
            UpdateCreatedObjData(createdDataSo);
            
            return createdDataSo.baseItemData.itemPrefab.Go;
        }
        

     
        private void UpdateCreatedObjData(BaseItemDataSo objToUpdate)
        {
            var count =  UpdateItemCount(objToUpdate, true);
            if (IsClamped(objToUpdate, count))
            {
                if (!objClamped.Contains(objToUpdate))
                    objClamped.Add(objToUpdate);
                objCanCreatable.Remove(objToUpdate);
            }
        }
        private void OnCollectedItemFromGround(BaseItemDataSo collectedDataSo)
        {
            var count =UpdateItemCount(collectedDataSo, false);
            if (!IsClamped(collectedDataSo, count))
            {
                objClamped.Remove(collectedDataSo);
                if(!objCanCreatable.Contains(collectedDataSo))
                    objCanCreatable.Add(collectedDataSo);
                    
                ItemActionManager.canCreateItems?.Invoke(true);
            }
        }
        private int UpdateItemCount(BaseItemDataSo itemToCheck, bool add)
        {
            if (createdObjAndCount.TryGetValue(itemToCheck, out _tempCount))
            {
                var val = add ? 1 : -1;
                _tempCount += val ;
                createdObjAndCount[itemToCheck] = _tempCount;
                return _tempCount;
            }
            else
            {
                createdObjAndCount.Add(itemToCheck, 1);
            }

            return 1;
        }
        private BaseItemDataSo GetItemToCreate()
        {
            return objCanCreatable[Random.Range(0, objCanCreatable.Count)];
        }
        private bool IsClamped(BaseItemDataSo objToCheck, int objCount)
        {
            for (int i = 0; i < objAndCountForClamp.Length; i++)
            {
                var currentClamp = objAndCountForClamp[i];
                if (objToCheck == currentClamp.itemDataSo)
                {
                    return objCount >= currentClamp.itemAmount;
                }
            }
            
            //DebugHelper.LogRed("THIS IS AN ERROR");
            return false;
        }
        private bool IsAllItemsClamped()
        {
            return objCanCreatable.Count == 0;
        }
        private void OnAvailableItemsUpdated()
        {
            for (int i = 0; i < itemManager.AvailableItems.Count; i++)
            {
                var currentAvailableItem = itemManager.AvailableItems[i];
                if(objClamped.Contains(currentAvailableItem))
                    continue;
                objCanCreatable.Add(currentAvailableItem);
            }
        }
    }
}