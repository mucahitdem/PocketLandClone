using Scripts.BaseGameScripts.Component;
using Sirenix.OdinInspector;

namespace Scripts.GameScripts.XpManagement
{
    public class XpSphere : BaseComponent
    {
        [ShowInInspector]
        public float Xp { get; private set; }

        public void LoadXp(float xpToLoad)
        {
            Xp = xpToLoad;
        }
    }
}