using Scripts.BaseGameScripts.StateManagement;
using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.State.GameStates
{
    public class GameState03_0Lose : BaseGameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.UiManager.ShowScreen(Defs.UI_KEY_LOSE_SCREEN);
        }

        public override void ExitState()
        {
        }
    }
}