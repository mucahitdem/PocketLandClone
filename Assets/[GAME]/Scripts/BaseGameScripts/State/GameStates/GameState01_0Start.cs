using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.State.GameStates
{
    public class GameState01_0Start : GameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.uiManager.ShowScreen(Defs.UI_KEY_START_SCREEN);
        }

        public override void ExitState()
        {
        }
    }
}