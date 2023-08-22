using Scripts.BaseGameScripts.InputManagement;
using Scripts.GameScripts;

namespace Scripts.BaseGameScripts.Control
{
    public abstract class BaseControl : InputHandler, IControl
    {
        public bool isControlEnabled;
        public abstract void GetInput();
    }
}