using Scripts.BaseGameScripts.EventManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.ComponentManagement
{
    public class BaseComponent : EventSubscriber
    {
        private Animator _anim;
        private Collider _col;
        private GameObject _go;
        private Rigidbody _rb;
        private RectTransform _rectTransformObj;
        private Transform _transformOfObj;

        [SerializeField]
        protected bool dontDestroyOnLoad;

        [ShowInInspector]
        [PropertyOrder(-1)]
        private int GoId => gameObject.GetInstanceID();

        public virtual RectTransform RectTransformObj
        {
            get
            {
                if (!_rectTransformObj)
                    _rectTransformObj = GetComponent<RectTransform>();
                return _rectTransformObj;
            }
            set => _rectTransformObj = value;
        }
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
        protected virtual Rigidbody Rb
        {
            get
            {
                if (!_rb)
                    _rb = GetComponent<Rigidbody>();
                return _rb;
            }
            set => _rb = value;
        }

        protected virtual Collider Col
        {
            get
            {
                if (!_col)
                    _col = GetComponent<Collider>();
                return _col;
            }
        }
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


        public virtual void Insert(BaseComponent baseComponent)
        {
        }
        public override void SubscribeEvent()
        {
        }
        public override void UnsubscribeEvent()
        {
        }
    }
}