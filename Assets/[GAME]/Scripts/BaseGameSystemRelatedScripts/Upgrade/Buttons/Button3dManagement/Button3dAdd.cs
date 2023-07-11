using Scripts.GameScripts.Button3dManagement;

namespace Scripts.BaseGameSystemRelatedScripts.Upgrade.Buttons.Button3dManagement
{
    public class Button3dAdd : BaseButton3D
    {
        protected override void Awake()
        {
            base.Awake();
            upgradableData = UpgradeDataSo.UpgradesData.upgradeData.addData;
        }
        

        protected override void OnMouseDown()
        {
            base.OnMouseDown();
            TryUpgrade();
        }
    }
}