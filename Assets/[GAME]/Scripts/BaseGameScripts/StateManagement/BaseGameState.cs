using Scripts.BaseGameScripts.ComponentManager;

namespace Scripts.BaseGameScripts.StateManagement
{
    public abstract class BaseGameState : BaseComponent
    {
        public abstract void InitState();
        public abstract void ExitState();
    }
}