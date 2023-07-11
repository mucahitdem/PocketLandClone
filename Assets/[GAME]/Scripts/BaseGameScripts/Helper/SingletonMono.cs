using UnityEngine;

namespace Scripts.BaseGameScripts.Helper
{
    public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T s_instance;

        public bool dontDestroyOnLoad;

        public static T Instance
        {
            get
            {
                if (!Application.isPlaying) 
                    s_instance = FindObjectOfType<T>();
                //BuildNewInstanceIfNull();
                return s_instance;
            }
            set => s_instance = value;
        }

        public static bool IsNull
        {
            get
            {
                if (!Application.isPlaying)
                    s_instance = FindObjectOfType<T>();
                return s_instance == null;
            }
        }

        protected virtual void Awake()
        {
            if (s_instance == null)
            {
                s_instance = this as T;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            (Instance as SingletonMono<T>)?.OnAwake();
            SetIfDontDestroyOnLoad();
        }

        private static void BuildNewInstanceIfNull()
        {
            if (s_instance == null)
            {
                var newObject = new GameObject("" + typeof(T).Name);
                s_instance = newObject.AddComponent<T>();
            }
        }

        private void SetIfDontDestroyOnLoad()
        {
            if (dontDestroyOnLoad)
            {
                //transform.parent = null;
                DontDestroyOnLoad(gameObject);
            }
        }

        protected abstract void OnAwake();
    }
}