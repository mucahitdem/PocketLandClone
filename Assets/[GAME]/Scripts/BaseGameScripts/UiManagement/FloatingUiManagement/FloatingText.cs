using System;
using System.Collections;
using Scripts.BaseGameScripts.Helper;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.UiManagement.FloatingUiManagement
{
    public class FloatingText : BaseFloatingUi
    {
        private Color _defaultColor;

        [SerializeField]
        private Text textVar;

        [SerializeField]
        private float fadeOutSpeed = 1000f;

        [SerializeField]
        private float upwardsSpeed = 1000f;

        private void Awake()
        {
            _defaultColor = textVar.color;
            _defaultColor.a = 1;
        }
        
        
        public override void SetData(string data)
        {
            textVar.text = data;

            StartCoroutine(FadeOutText(() =>
            {
                BasePoolItem.AddObjToPool(this);
            }));
            
            // textVar.DOFade(0, 1);
            // TransformOfObj.DOMoveY(1, 1)
            //     .SetRelative(true)
            //     .OnComplete(() => { BasePoolItem.AddObjToPool(this); });
        }
        protected override void ResetData()
        {
            _defaultColor.a = 1;
            textVar.color = _defaultColor;
        }
        
        
        private IEnumerator FadeOutText(Action onCompleted)
        {
            ResetData();
            while (_defaultColor.a > 0.0f)
            {
                MoveUpwards();
                _defaultColor.a -= Time.deltaTime * fadeOutSpeed;
                textVar.color = _defaultColor;
                yield return null;
            }
            onCompleted?.Invoke();
        }
        private void MoveUpwards()
        {
            TransformOfObj.position += Vector3.up * (Time.deltaTime * upwardsSpeed);
        }
    }
}