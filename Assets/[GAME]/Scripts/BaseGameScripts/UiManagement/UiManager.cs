using System.Collections.Generic;
using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using Scripts.GameScripts;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Scripts.BaseGameScripts.UiManagement
{
    public class UiManager : BaseComponent
    {
        private readonly Dictionary<string, BaseUiItem> _idAndItems = new Dictionary<string, BaseUiItem>();

        [Title("Temp Variables")]
        private BaseUiItem _baseUiItem;

        [SerializeField]
        [ReadOnly]
        private BaseUiItem[] allUiItems;

        protected override void OnEnable()
        {
            base.OnEnable();
            GetAllUiItems();
        }

        private void GetAllUiItems()
        {
            allUiItems = GetComponentsInChildren<BaseUiItem>(true);
            for (var i = 0; i < allUiItems.Length; i++)
            {
                var currentUi = allUiItems[i];
                if (currentUi.UiItemId.IsNullOrWhitespace())
                    continue;

                try
                {
                    if (currentUi.UiItemId == Defs.UI_KEY_NOT_IMPLEMENTED)
                    {
                        //DebugHelper.LogRed("THIS IS A BUG OR STH");
                        continue;
                    }

                    _idAndItems.Add(currentUi.UiItemId, currentUi);
                }
                catch
                {
                    //DebugHelper.LogRed("NOT IMPLEMENTED UI ID");
                }
            }
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            UiActionManager.showUiItem += ShowItem;
            UiActionManager.hideUiItem += HideItem;
            UiActionManager.addNewUiItem += AddUiItem;
            UiActionManager.getUiItem += GetUiItem;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            UiActionManager.showUiItem -= ShowItem;
            UiActionManager.hideUiItem -= HideItem;
            UiActionManager.addNewUiItem -= AddUiItem;
            UiActionManager.getUiItem -= GetUiItem;
        }


        private BaseUiItem GetUiItem(string id)
        {
            if (_idAndItems.TryGetValue(id, out _baseUiItem))
            {
                return _baseUiItem;
            }

            //DebugHelper.LogRed("THERE IS NO UI ITEM WITH ID : " + id);
            return null;
        }

        private void ShowItem(string id, Object component)
        {
            if (_idAndItems.TryGetValue(id, out _baseUiItem))
            {
                _baseUiItem.ShowUi(component);
                return;
            }

            //DebugHelper.LogRed("THERE IS NO UI ITEM WITH ID : " + id);
        }

        private void HideItem(string id, Object component)
        {
            if (_idAndItems.TryGetValue(id, out _baseUiItem))
            {
                _baseUiItem.HideUi(component);
                return;
            }

            //DebugHelper.LogRed("THERE IS NO UI ITEM WITH ID : " + id);
        }

        private void AddUiItem(string id, BaseUiItem uiItem)
        {
            if (_idAndItems.TryGetValue(id, out _baseUiItem) == false)
            {
                _idAndItems.Add(id, uiItem);
            }
            else
            {
                //DebugHelper.LogRed("THERE IS AN UI ITEM ALREADY EXIST WITH ID : " + id);
            }
        }
    }
}