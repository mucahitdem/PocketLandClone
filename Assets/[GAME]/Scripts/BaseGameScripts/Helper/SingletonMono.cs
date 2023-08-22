using UnityEngine;

namespace Scripts.BaseGameScripts.Helper
{
    public abstract class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T s_instance;

        [SerializeField]
        private bool dontDestroyOnLoad;

        public static T Instance
        {
            get
            {
                if (!s_instance)
                {
                    s_instance = FindObjectOfType<T>();

                    if (!s_instance)
                    {
                        var singletonObject = new GameObject(typeof(T).Name);
                        s_instance = singletonObject.AddComponent<T>();
                    }

                    //DontDestroyOnLoad(s_instance.gameObject);
                }
                else
                {
                    var existingInstances = FindObjectsOfType<T>();
                    foreach (var existingInstance in existingInstances)
                        if (existingInstance != s_instance)
                            Destroy(existingInstance.gameObject);
                }

                return s_instance;
            }
        }

        protected virtual void Awake()
        {
            if (dontDestroyOnLoad)
            {
                transform.SetParent(null);
                DontDestroyOnLoad(gameObject);
            }

            OnAwake();
        }

        protected abstract void OnAwake();
    }
}