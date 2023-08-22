using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.Animator_Control
{
    [Serializable]
    public class AnimatorParameterController
    {
        private Dictionary<string, int> _animKeysAndIndexInList = new Dictionary<string, int>();

        private int _value;

        [SerializeField]
        [ShowInInspector]
        private List<AnimatorParameter> animatorParameters = new List<AnimatorParameter>();

        public void CalculateKeys()
        {
            _animKeysAndIndexInList.Clear();
            for (var i = 0; i < animatorParameters.Count; i++)
            {
                var animatorParameter = animatorParameters[i];
                animatorParameter.CalculateHashKey();
                _animKeysAndIndexInList.Add(animatorParameter.parameterName, i);
            }
        }

        public int GetHashKey(string key)
        {
            if (_animKeysAndIndexInList.TryGetValue(key, out _value)) return animatorParameters[_value].hashKey;

            AddParameterName(key);
            if (_animKeysAndIndexInList.TryGetValue(key, out _value))
                return animatorParameters[_value].hashKey;

            //DebugHelper.LogYellow("PLEASE ADD THE KEY BEFORE USING IT");
            return -1;
        }

        public void AddParameterName(string keyToAdd)
        {
            animatorParameters.Add(new AnimatorParameter(keyToAdd));
            _animKeysAndIndexInList.Add(keyToAdd, animatorParameters.Count - 1);
        }
    }
}