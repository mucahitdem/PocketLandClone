using Scripts.BaseGameScripts.Helper;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.UI
{
    public class UiButton : UiItem
    {
        private Button _button;

        protected Button Button
        {
            get
            {
                if (!_button)
                    _button = GetComponentInChildren<Button>();
                return _button;
            }
            set => _button = value;
        }

        public override void SubscribeEvent()
        {
            base.SubscribeEvent();
            if(Button)
                Button.onClick.AddListener(OnClick);
            else
                DebugHelper.LogRed("NO BUTTON FOUND !!!! ");
        }

        public override void UnsubscribeEvent()
        {
            base.SubscribeEvent();
            if(Button)
                Button.onClick.RemoveListener(OnClick);
        }

        protected virtual void OnClick()
        {
        }
    }
}