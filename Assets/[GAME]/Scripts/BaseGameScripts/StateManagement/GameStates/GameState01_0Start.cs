using Scripts.BaseGameScripts.StateManagement;
using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.State.GameStates
{
    public class GameState01_0Start : BaseGameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.UiManager.ShowScreen(Defs.UI_KEY_START_SCREEN);
        }

        public override void ExitState()
        {
        }
    }
}