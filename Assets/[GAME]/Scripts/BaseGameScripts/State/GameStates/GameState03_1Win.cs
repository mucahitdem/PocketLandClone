using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.State.GameStates
{
    public class GameState03_1Win : GameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.uiManager.ShowScreen(Defs.UI_KEY_WIN_SCREEN);
        }

        public override void ExitState()
        {
        }
    }
}