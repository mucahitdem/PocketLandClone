using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.Animator_Control
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
            //DebugHelper.LogYellow("HASH KEY OF " + parameterName + " is " + hashKey);
        }
    }
}