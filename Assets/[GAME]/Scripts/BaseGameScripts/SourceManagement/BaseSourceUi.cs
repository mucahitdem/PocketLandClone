using System;
using Scripts.BaseGameScripts.SourceManagement;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.SourceManagement
{
    public class BaseSourceUi : BaseUiItem
    {
        [SerializeField]
        private BaseSourceDataSo baseSourceDataSo;

        [SerializeField]
        private TextMeshProUGUI currentSource;

        [SerializeField]
        private Image sourceIcon;

        private void Awake()
        {
            sourceIcon.sprite = baseSourceDataSo.baseSourceData.sourceIcon;
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            SourceActionManager.onSourceUpdated += OnSourceUpdated;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            SourceActionManager.onSourceUpdated -= OnSourceUpdated;
        }

        private void OnSourceUpdated(int sourceAmount)
        {
            currentSource.text = sourceAmount.ToString();
        }
    }
}