using Scripts.BaseGameSystemRelatedScripts.Upgrade;

namespace Scripts.GameScripts.Button3dManagement
{
    public class Button3dIncome : BaseButton3D
    {
        protected override void Awake()
        {
            base.Awake();
            upgradableData = UpgradeDataSo.UpgradesData.upgradeData.incomeData;
        }
        
        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            TryUpgrade();
        }
    }
}