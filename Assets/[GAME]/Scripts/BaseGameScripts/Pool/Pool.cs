using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.BaseGameScripts.Pool
{
    public class Pool : MonoBehaviour
    {
        [SerializeField]
        private BaseComponent obj;
        
        [HideInInspector]
        public PoolPattern pool;
        
        [SerializeField]
        private int itemCount;
        
        [SerializeField]
        private HideFlags hideFlag;

        public void Awake()
        {
            pool = new PoolPattern(obj, itemCount, hideFlag);
        }
    }
}