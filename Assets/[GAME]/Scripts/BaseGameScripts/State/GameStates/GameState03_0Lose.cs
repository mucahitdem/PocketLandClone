using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.State.GameStates
{
    public class GameState03_0Lose : GameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.uiManager.ShowScreen(Defs.UI_KEY_LOSE_SCREEN);
        }

        public override void ExitState()
        {
        }
    }
}