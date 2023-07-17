using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.UI;

namespace Scripts.BaseGameSystemRelatedScripts.UI
{
    public class StartPanel : UiButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            GlobalReferences.Instance.GameStateManager.NextState();
        }
    }
}