using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.State._Interface;
using Scripts.BaseGameScripts.State.GameStates;
using Scripts.BaseGameScripts.UI;

namespace Scripts.BaseGameSystemRelatedScripts.UI
{
    public class StartButton : UiButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            GlobalReferences.Instance.GameStateManager.NextState(((IGameState)typeof(GameState03_1Win)));
        }
    }
}