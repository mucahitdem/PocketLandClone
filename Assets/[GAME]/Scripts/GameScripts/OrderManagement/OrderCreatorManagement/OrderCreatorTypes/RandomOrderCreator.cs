using System.Collections;
using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SourceManagement;
using Scripts.GameScripts.ItemManagement;
using Scripts.GameScripts.OrderManagement.Order;
using Scripts.GameScripts.StatsManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement.OrderCreatorManagement.OrderCreatorTypes
{
    public class RandomOrderCreator : BaseOrderCreator
    {
        [SerializeField]
        private BaseSourceDataSo sourceToEarn;
        
        [SerializeField]
        private StatsPerLevelByAnimCurve orderAmountMaxValueByPlayerLevel;

        [SerializeField]
        private StatsPerLevelByAnimCurve orderAmountMinValueByPlayerLevel;


        private List<ItemTypeAndCount> itemTypeAndCount = new List<ItemTypeAndCount>();
        private ItemManager itemManager;
        
        protected override void Start()
        {
            base.Start();
            itemManager = GameManager.Instance.ItemManager;
            StartCoroutine(FakeStart());
        }
        private IEnumerator FakeStart()
        {
            yield return new WaitForEndOfFrame();

            for (int i = 0; i < 4; i++)
            {
                CreateNewOrder();   
            }
        }


        public override void CreateNewOrder()
        {
            var randomItemAndCount = RandomItemTypeAndCount();
            var baseOrder = new BaseOrder(new BaseOrderData(randomItemAndCount, sourceToEarn));
            OrderActionManager.onNewOrderCreated?.Invoke(baseOrder);
        }


        private List<ItemTypeAndCount> RandomItemTypeAndCount()
        {
            itemTypeAndCount.Clear();
            itemTypeAndCount.Add(new ItemTypeAndCount(RandomItemInAvailableItems(), RandomItemCount()));
            return itemTypeAndCount;
        }
        private BaseItemDataSo RandomItemInAvailableItems()
        {
            var randomIndex = Random.Range(0, itemManager.AvailableItems.Count);
            return itemManager.AvailableItems[randomIndex];
        }
        private int RandomItemCount()
        {
            var randomValue = Random.Range(orderAmountMinValueByPlayerLevel.GetStatWithLevel(PlayerLevel),
                orderAmountMaxValueByPlayerLevel.GetStatWithLevel(PlayerLevel));
            return (int) randomValue;
        }
    }
}