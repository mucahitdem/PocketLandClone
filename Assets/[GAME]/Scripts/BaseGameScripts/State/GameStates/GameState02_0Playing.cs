using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.State.GameStates
{
    public class GameState02_0Playing : GameState
    {
        public override void InitState()
        {
            GlobalReferences.Instance.uiManager.ShowScreen(Defs.UI_KEY_GAMEPLAY_SCREEN);
        }

        public override void ExitState()
        {
        }
    }
}