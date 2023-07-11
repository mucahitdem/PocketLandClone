using Scripts.BaseGameScripts.Component;
using Scripts.State._Interface;

namespace Scripts.BaseGameScripts.State
{
    public abstract class GameState : BaseComponent, IGameState
    {
        public abstract void InitState();

        public abstract void ExitState();
    }
}