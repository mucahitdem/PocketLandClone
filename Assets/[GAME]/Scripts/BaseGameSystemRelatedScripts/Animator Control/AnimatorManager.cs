using Scripts.BaseGameScripts.Component;
using Sirenix.Utilities;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.Animator_Control
{
    public class AnimatorManager : BaseComponent
    {
        public override Animator AnimOfObj => animOfObj;

        [SerializeField]
        private AnimatorParameterController animatorParameterController;

        [SerializeField]
        private Animator animOfObj;

        private string _prevKey;

        private void Awake()
        {
            animatorParameterController.CalculateKeys();
        }

        public void SetTrigger(string key)
        {
            AnimOfObj.SetTrigger(animatorParameterController.GetHashKey(key));
        }

        public void SetBool(string key, bool isEnabled, bool reset = false)
        {
            if(reset)
                ResetPrevKey();
            
            AnimOfObj.SetBool(animatorParameterController.GetHashKey(key), isEnabled);
            _prevKey = key;
        }

        private void ResetPrevKey()
        {
            if (!_prevKey.IsNullOrWhitespace())
                AnimOfObj.SetBool(animatorParameterController.GetHashKey(_prevKey), false);
        }

        public void SetFloat(string key, float value)
        {
            AnimOfObj.SetFloat(animatorParameterController.GetHashKey(key), value);
        }
        
        public void SetInt(string key, int value)
        {
            AnimOfObj.SetInteger(animatorParameterController.GetHashKey(key), value);
        }
        
        public bool GetBool(string key)
        {
            return AnimOfObj.GetBool(animatorParameterController.GetHashKey(key));
        }
    }
}