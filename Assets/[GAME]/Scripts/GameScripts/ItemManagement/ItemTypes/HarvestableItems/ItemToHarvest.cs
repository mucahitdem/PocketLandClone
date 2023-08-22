namespace Scripts.GameScripts.ItemManagement.ItemTypes.HarvestableItems
{
    public class ItemToHarvest : BaseItem
    {
        private ItemToHarvestDataSo itemToHarvestData;
        public override BaseItemDataSo BaseItemDataSo => baseItemDataSo;

        protected override void OnEnable()
        {
            base.OnEnable();
            itemToHarvestData = (ItemToHarvestDataSo) baseItemDataSo;
        }
    }
}