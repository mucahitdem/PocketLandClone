using System;
using Scripts.BaseGameScripts.SourceManagement;
using Scripts.BaseGameScripts.SourceManagement.SourceTypes;
using Scripts.BaseGameScripts.UiManagement.BaseUiItemManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.SourceManagement
{
    public class ClampedSourceUi : BaseUiItem
    {
        [SerializeField]
        private RenewableClampedSourceDataSo clampedSourceDataSo;

        [SerializeField]
        private TextMeshProUGUI sourceAmount;

        [SerializeField]
        private Image sourceIcon;

        private void Awake()
        {
            sourceIcon.sprite = clampedSourceDataSo.baseSourceData.sourceIcon;
        }

        protected override string GetUiId()
        {
            throw new NotImplementedException();
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            SourceActionManager.onClampedSourceUpdated += OnClampedSourceUpdated;
        }

        private void OnClampedSourceUpdated(int currentSource, int maxSource)
        {
            sourceAmount.text = currentSource + "/" + maxSource;
        }
    }
}