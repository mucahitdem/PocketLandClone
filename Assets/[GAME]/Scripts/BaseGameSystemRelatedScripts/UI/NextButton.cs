using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.UI;

namespace Scripts.BaseGameSystemRelatedScripts.UI
{
    public class NextButton : UiButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            GlobalReferences.Instance.levelManager.NextLevel();
        }
    }
}