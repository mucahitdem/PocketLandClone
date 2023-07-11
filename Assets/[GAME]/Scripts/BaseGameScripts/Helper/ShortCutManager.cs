using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.BaseGameScripts.Helper
{
    public class ShortCutManager : MonoBehaviour
    {
        private ShortCutData _shortCutData;
        public List<ShortCutData> keycodes = new List<ShortCutData>();

        private void Update()
        {
            for (var i = 0; i < keycodes.Count; i++)
            {
                _shortCutData = keycodes[i];
                if (UnityEngine.Input.GetKeyDown(_shortCutData.keyCode)) _shortCutData.unityEvent?.Invoke();
            }
        }
    }

    [Serializable]
    public class ShortCutData
    {
        [FoldoutGroup("Data")]
        [GUIColor(0.3f, 0.8f, 0.8f)]
        public KeyCode keyCode;

        [FoldoutGroup("Data")]
        [GUIColor(0.3f, 0.8f, 0.8f)]
        public UnityEvent unityEvent;
    }
}