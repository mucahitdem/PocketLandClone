using System;

namespace Scripts.GameScripts.ItemManagement.ItemTypes.HarvestableItems
{
    public class ItemToHarvest : BaseItem
    {
        public override BaseItemDataSo BaseItemDataSo => baseItemDataSo;
        
        private ItemToHarvestDataSo itemToHarvestData;

        public override void OnEnable()
        {
            base.OnEnable();
            itemToHarvestData = (ItemToHarvestDataSo) baseItemDataSo;
        }
    }
}