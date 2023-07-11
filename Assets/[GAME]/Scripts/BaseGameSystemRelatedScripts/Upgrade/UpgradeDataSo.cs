using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.Upgrade
{
    [CreateAssetMenu(menuName = "Base Game/UpgradeData")]
    public class UpgradeDataSo : ScriptableObject
    {
        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static UpgradeDataSo s_mUpgradeData;

        public static UpgradeDataSo UpgradesData => s_mUpgradeData ??= Resources.Load<UpgradeDataSo>("UpgradeData");

        private void FindHolesDataAsset()
        {
            if (UpgradesData) return;
            Debug.LogError("HoleData asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
        
        [HideLabel]
        public UpgradeData upgradeData;
        private static IncomeData IncomeData => UpgradesData.upgradeData.incomeData;
        private static AddData AddData => UpgradesData.upgradeData.addData;

#if UNITY_EDITOR
        public void SetDataDirty()
        {
            EditorUtility.SetDirty(UpgradesData);
        }
#endif

        public static void ResetData()
        {
            IncomeData.Reset();
            AddData.Reset();
        }
    }
}