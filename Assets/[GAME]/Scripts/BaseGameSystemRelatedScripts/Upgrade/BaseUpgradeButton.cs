using System.Globalization;
using DG.Tweening;
using Scripts.BaseGameScripts.CoinControl;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameSystemRelatedScripts.Upgrade
{
    public abstract class BaseUpgradeButton : UiButton
    {
        private Image _bgImage;
        private CoinManager _coinManager;

        private float _cost;
        public Button button;
        public TextMeshPro costText;
        public Image icon;
        public Text levelText;
        public Text nameOfButton;
        protected UpgradableData upgradableData;

        private bool _canPlayAnim;

        protected virtual void Awake()
        {
            _bgImage = GetComponent<Image>();
            _canPlayAnim = true;
        }

        protected virtual void Start()
        {
            _coinManager = CoinManager.Instance;
            OnUpgradeCountChanged();
        }

        #region Subs

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            CoinManager.onCoinCountChanged += OnCoinCountChanged;
        }

        public override void UnsubscribeEvent()
        {
            base.UnsubscribeEvent();
            CoinManager.onCoinCountChanged -= OnCoinCountChanged;
        }

        #endregion
        
        protected override void OnClick()
        {
            base.OnClick();
            TryUpgrade();
        }

        protected void TryUpgrade()
        {
            if (upgradableData.UpgradeMaxed) 
                return;
            
            var upCost = upgradableData.UpgradeCost;
            if (!_coinManager.CheckIfYouHaveEnoughCoin(upCost))
                //NotEnoughTextController.NotEnoughAction?.Invoke();
                return;
            
            if (_canPlayAnim)
            {
                _canPlayAnim = false;
                TransformOfObj.DOPunchScale(Vector3.one * .1f, .3f)
                    .OnComplete(() =>
                    {
                        _canPlayAnim = true;
                    });
            }
           
            CoinManager.Instance.SpendCoin(upCost);
            upgradableData.Upgrade();

            OnUpgradeCountChanged();
            
            if (upgradableData.UpgradeMaxed) 
                ButtonControl(false);
        }

        private void OnUpgradeCountChanged()
        {
            UpdateLevel();
            UpdateCost();
        }

        private void OnCoinCountChanged(float obj)
        {
            // button activate controller
        }

        #region Button Data

        private void UpdateLevel()
        {
            if (levelText)
                levelText.text = "LEVEL " + upgradableData.UpgradeLevel;
        }

        private void UpdateCost()
        {
            _cost = upgradableData.GetCost();
            var costOfTx = _cost > 999
                ? MoneyConverter.CurrencyConvert(_cost)
                : _cost.ToString(CultureInfo.InvariantCulture);
            costText.text = _cost < 0 ? "MAX" : "$" + costOfTx;
        }

        #endregion

        #region Button Situation

        protected void ButtonControl(bool isActive)
        {
            if(button)
                button.interactable = isActive;
           
            ButtonActivateControlVisually(isActive);
        }

        private void ButtonActivateControlVisually(bool isActive)
        {
            if(nameOfButton)
                nameOfButton.enabled = isActive;
            if(icon)
                icon.enabled = isActive;
            
            //costText.enabled = isActive;
            if (_bgImage)
            {
                _bgImage.enabled = isActive;
                _bgImage.raycastTarget = isActive;
            }
        }

        #endregion
    }
}