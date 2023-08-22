using System;
using Scripts.BaseGameScripts.Pool;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.UiManagement.FloatingUiManagement
{
    public abstract class BaseFloatingUi : BaseUiItem
    {
        [SerializeField]
        private BasePoolItem basePoolItem;

        public BasePoolItem BasePoolItem => basePoolItem;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            BasePoolItem.onSendToPool += ResetData;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            BasePoolItem.onSendToPool -= ResetData;
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }

        public abstract void SetData(string data);

        protected virtual void ResetData()
        {
        }
    }
}