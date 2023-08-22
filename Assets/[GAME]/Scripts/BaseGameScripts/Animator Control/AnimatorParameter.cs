using System;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.Animator_Control
{
    [Serializable]
    public class AnimatorParameter
    {
        [ReadOnly]
        public int hashKey;

        public string parameterName;

        public AnimatorParameter(string parameterName)
        {
            this.parameterName = parameterName;
            CalculateHashKey();
        }

        public void CalculateHashKey()
        {
            hashKey = Animator.StringToHash(parameterName);
            DebugHelper.LogYellow("HASH KEY OF " + parameterName + " is " + hashKey);
        }
    }
}