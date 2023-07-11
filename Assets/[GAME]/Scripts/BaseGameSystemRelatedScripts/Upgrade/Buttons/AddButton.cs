

namespace Scripts.BaseGameSystemRelatedScripts.Upgrade.Buttons
{
    public class AddButton : BaseUpgradeButton
    {
        protected override void Awake()
        {
            base.Awake();
            upgradableData = UpgradeDataSo.UpgradesData.upgradeData.addData;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            //CellManager.cellsFilled += OnGridsFilled;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            //CellManager.cellsFilled -= OnGridsFilled;
        }
        
        private void OnGridsFilled(bool isFilled)
        {
            ButtonControl(isFilled);
        }
    }
}