using Scripts.BaseGameScripts.Component;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.XpManagement
{
    public class XpSphere : BaseComponent
    {
        [ShowInInspector]
        public float Xp => _xp;
        
        private float _xp;

        public void LoadXp(float xpToLoad)
        {
            _xp = xpToLoad;
        }
    }
}