using Scripts.BaseGameScripts.Component;
using Sirenix.Utilities;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.Animator_Control
{
    public class AnimatorStateManager : BaseComponent
    {
        public override Animator AnimOfObj => animOfObj;

        [SerializeField]
        private AnimatorParameterController animatorParameterController;

        [SerializeField]
        private Animator animOfObj;

        private string _prevTriggerKey;
        private string _prevBoolKey;

        private void Awake()
        {
            animatorParameterController.CalculateKeys();
        }

        public void SetTrigger(string key, bool reset = false)
        {
            if(reset)
                ResetAllPrevKey();
            
            AnimOfObj.SetTrigger(animatorParameterController.GetHashKey(key));
            _prevTriggerKey = key;
        }
        public void SetBool(string key, bool isEnabled, bool reset = false)
        {
            if(reset)
                ResetAllPrevKey();
            
            AnimOfObj.SetBool(animatorParameterController.GetHashKey(key), isEnabled);
            _prevBoolKey = key;
        }

        private void ResetAllPrevKey()
        {
            StopPlaying();
            if (!_prevBoolKey.IsNullOrWhitespace())
            {
                AnimOfObj.SetBool(animatorParameterController.GetHashKey(_prevBoolKey), false);
            }
            
            if (!_prevTriggerKey.IsNullOrWhitespace())
            {
                AnimOfObj.ResetTrigger(animatorParameterController.GetHashKey(_prevTriggerKey));
            }
        }

        private void StopPlaying()
        {
            animOfObj.Rebind();
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