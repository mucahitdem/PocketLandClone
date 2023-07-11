using Scripts.BaseGameScripts.CoinControl;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameSystemRelatedScripts.UI
{
    public class CoinUi : UiItem
    {
        [SerializeField]
        private Text coinCount;

        public Image coinIcon;

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            CoinManager.onCoinCountChanged += UpdateCoinCount;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            CoinManager.onCoinCountChanged -= UpdateCoinCount;
        }

        private void UpdateCoinCount(float newCoinCount)
        {
            coinCount.text = MoneyConverter.CurrencyConvert(newCoinCount);
        }
    }
}