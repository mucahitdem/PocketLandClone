using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.UI;

namespace Scripts.BaseGameSystemRelatedScripts.UI
{
    public class StartButton : UiButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            GlobalReferences.Instance.GameStateManager.NextState(true);
        }
    }
}