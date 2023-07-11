using Scripts.BaseGameScripts.EventManagement;
using UnityEngine;

namespace Scripts.BaseGameScripts.Component
{
    public class BaseComponent : EventSubscriber
    {
        private Collider _col;
        private GameObject _go;
        private LineRenderer _lineRenderer;
        private Rigidbody _rb;
        private RectTransform _rect;
        private Transform _transformOfObj;
        private Animator _anim;
        private Renderer _rendOfObj;

        public Transform TransformOfObj
        {
            get
            {
                if (!_transformOfObj)
                    _transformOfObj = transform;
                return _transformOfObj;
            }
            set => _transformOfObj = value;
        }
        public GameObject Go
        {
            get
            {
                if (!_go)
                    _go = gameObject;
                return _go;
            }
            set => _go = value;
        }
        public Rigidbody Rb
        {
            get
            {
                if (!_rb)
                    _rb = GetComponent<Rigidbody>();
                return _rb;
            }
            set => _rb = value;
        }
        public Collider Col
        {
            get
            {
                if (!_col)
                    _col = GetComponent<Collider>();
                return _col;
            }
            set => _col = value;
        }
        protected RectTransform Rect
        {
            get
            {
                if (!_rect)
                    _rect = GetComponent<RectTransform>();
                return _rect;
            }
            set => _rect = value;
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

        protected LineRenderer LineRend
        {
            get
            {
                if (!_lineRenderer) _lineRenderer = GetComponent<LineRenderer>();
                return _lineRenderer;
            }
            set => _lineRenderer = value;
        }

        protected Renderer RendOfObj
        {
            get
            {
                if (!_rendOfObj)
                {
                    _rendOfObj = GetComponent<Renderer>();

                    if (!_rendOfObj)
                        _rendOfObj = GetComponentInChildren<Renderer>();
                }
                   

                return _rendOfObj;
            }
            set => _rendOfObj = value;
        }
        
        
        
        public override void SubscribeEvent()
        {
        }

        public override void UnsubscribeEvent()
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
    }
}