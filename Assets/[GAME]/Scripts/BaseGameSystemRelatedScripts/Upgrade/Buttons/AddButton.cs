

namespace Scripts.BaseGameSystemRelatedScripts.Upgrade.Buttons
{
    public class AddButton : BaseUpgradeButton
    {
        protected override void Awake()
        {
            base.Awake();
            upgradableData = UpgradeDataSo.UpgradesData.upgradeData.addData;
        }

        protected override void SubscribeEvent()
        {
            base.SubscribeEvent();
            //CellManager.cellsFilled += OnGridsFilled;
        }

        protected override void UnsubscribeEvent()
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