using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.StateManagement.GameStates
{
    public class GameState02_0Playing : BaseGameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.UiManager.ShowScreen(Defs.UI_KEY_GAMEPLAY_SCREEN);
        }

        public override void ExitState()
        {
        }
    }
}