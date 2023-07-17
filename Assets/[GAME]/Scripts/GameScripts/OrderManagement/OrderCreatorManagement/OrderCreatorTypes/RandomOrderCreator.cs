using System.Collections.Generic;
using Scripts.GameScripts.ItemManagement;
using Scripts.GameScripts.OrderManagement.Order;
using Scripts.GameScripts.StatsManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.OrderManagement.OrderCreatorManagement.OrderCreatorTypes
{
    public class RandomOrderCreator : BaseOrderCreator
    {
        private ItemManager itemManager;

        [Title("Temp Variables")]
        private List<ItemTypeAndCount> itemTypeAndCount;

        [SerializeField]
        private StatsPerLevelByAnimCurve orderAmountMaxValueByPlayerLevel;

        [SerializeField]
        private StatsPerLevelByAnimCurve orderAmountMinValueByPlayerLevel;


        protected override void Start()
        {
            base.Start();
            itemManager = GameManager.Instance.ItemManager;
        }


        public override void CreateNewOrder()
        {
            var baseOrder = new BaseOrder(new BaseOrderData(RandomItemTypeAndCount()));
        }


        private List<ItemTypeAndCount> RandomItemTypeAndCount()
        {
            itemTypeAndCount.Clear();

            itemTypeAndCount.Add(new ItemTypeAndCount(RandomItemInAvailableItems(), RandomItemCount()));

            return null;
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