using Scripts.BaseGameScripts;
using Scripts.BaseGameScripts.State.GameStates;
using Scripts.BaseGameScripts.UI;
using Scripts.State._Interface;

namespace Scripts.BaseGameSystemRelatedScripts.UI
{
    public class StartButton : UiButton
    {
        protected override void OnClick()
        {
            base.OnClick();
            GlobalReferences.Instance.gameStateManager.NextState(((IGameState)typeof(GameState03_1Win)));
        }
    }
}