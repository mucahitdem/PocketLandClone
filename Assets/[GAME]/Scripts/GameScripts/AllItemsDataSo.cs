using Scripts.GameScripts.ItemManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts
{
    [CreateAssetMenu(fileName = "AllItemsDataSo", menuName = "Game/Static Data/AllItemsDataSo", order = 0)]
    public class AllItemsDataSo : ScriptableObject
    {
        #region StaticSO

        [ShowInInspector]
        //[DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllItemsDataSo s_instance;

        public static AllItemsDataSo Instance => s_instance ??= Resources.Load<AllItemsDataSo>("AllItemsDataSo");

        private void FindHolesDataAsset()
        {
            if (Instance) 
                return;
            Debug.LogError("AllItemsDataSo asset of type HoleDataSo is missing in the resources folder.");
        }

        #endregion
        
        public BaseItemDataSo[] items;
    }
}