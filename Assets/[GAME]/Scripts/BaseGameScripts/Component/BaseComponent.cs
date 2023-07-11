using Scripts.BaseGameScripts.EventManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.Component
{
    public class BaseComponent : EventSubscriber
    { 
        private Transform _transformOfObj;
        public virtual Transform TransformOfObj
        {
            get
            {
                if (!_transformOfObj)
                    _transformOfObj = transform;
                return _transformOfObj;
            }
            set => _transformOfObj = value;
        }
        
        
        private GameObject _go;
        public virtual GameObject Go
        {
            get
            {
                if (!_go)
                    _go = gameObject;
                return _go;
            }
            set => _go = value;
        }
        
        
        private Rigidbody _rb;
        public virtual Rigidbody Rb
        {
            get
            {
                if (!_rb)
                    _rb = GetComponent<Rigidbody>();
                return _rb;
            }
            set => _rb = value;
        }
        
        
        private Collider _col;
        public virtual Collider Col
        {
            get
            {
                if (!_col)
                    _col = GetComponent<Collider>();
                return _col;
            }
            set => _col = value;
        }
        
        
        private Animator _anim;
        public virtual Animator AnimOfObj
        {
            get
            {
                if (!_anim)
                    _anim = GetComponent<Animator>();

                return _anim;
            }
            private set => _anim = value;
        }

        
        /// <summary>
        /// This function helps us to send data from manager class to composite classes
        /// </summary>
        /// <param name="baseComponent"></param>
        public virtual void Insert(BaseComponent baseComponent)
        {
        }
        
        public virtual void OnGetFromPool()
        {
            TransformOfObj.parent = null;
            Go.hideFlags = HideFlags.None;
            Go.SetActive(true);
        }

        public virtual void OnPushToPool()
        {
            TransformOfObj.parent = null;
            Go.hideFlags = HideFlags.HideInHierarchy;
            Go.SetActive(false);
        }
        
        
        
        protected override void SubscribeEvent()
        {
        }

        protected override void UnsubscribeEvent()
        {
        }
    }
}