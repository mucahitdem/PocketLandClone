using Scripts.GameScripts.ItemManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts
{
    [CreateAssetMenu(fileName = "All Items Data So", menuName = "Game/Static Data/All Items Data So", order = 0)]
    public class AllItemsDataSo : ScriptableObject
    {
        public BaseItemDataSo[] items;

        #region StaticSO

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllItemsDataSo s_instance;

        public static AllItemsDataSo Instance => s_instance ??= Resources.Load<AllItemsDataSo>("All Items Data So");

        private void FindHolesDataAsset()
        {
            if (Instance) return;
            Debug.LogError("AllItemsDataSo asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
    }
}