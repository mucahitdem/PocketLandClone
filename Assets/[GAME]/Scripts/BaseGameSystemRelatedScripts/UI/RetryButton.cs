using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.UI;

namespace Scripts.BaseGameSystemRelatedScripts.UI
{
    public class RetryButton : UiButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            GlobalReferences.Instance.levelManager.RetryLevel();
        }
    }
}