using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Scripts.GameScripts.SceneLoadingManagement
{
    [Serializable]
    public class SceneSerialization
    {
        public bool IsActiveScene => isActiveScene;
        public bool NeverUnloadScene => neverUnloadScene;
        
        [SerializeField]
        private bool isActiveScene;

        [SerializeField]
        private bool neverUnloadScene;


        [SerializeField]
        private Object scene;

        public string sceneName;
        public Object Scene => scene;

        [Button]
        private void GetName()
        {
            sceneName = scene.name;
        }
    }
}