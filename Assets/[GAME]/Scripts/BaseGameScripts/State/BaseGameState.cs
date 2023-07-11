using Scripts.BaseGameScripts.Component;
using Scripts.State._Interface;

namespace Scripts.BaseGameScripts.State
{
    public abstract class BaseGameState : BaseComponent, IGameState
    {
        public abstract void InitState();

        public abstract void ExitState();
    }
}