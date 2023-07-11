using Scripts.BaseGameScripts.UI;

namespace Scripts.BaseGameSystemRelatedScripts.UI
{
    public class WatchAdButton : UiButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            //AdSystem.Instance.ShowRewardedAd();
        }
    }
}