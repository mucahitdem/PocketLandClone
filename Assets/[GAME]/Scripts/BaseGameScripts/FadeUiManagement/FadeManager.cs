using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.UiManagement.FadeUiManagement
{
    public class FadeManager : MonoBehaviour
    {
        [SerializeField]
        private float fadeDuration;

        [SerializeField]
        private Image fadeImage;

        public void Fade(Action doOnFaded)
        {
            FadeIn(() =>
            {
                doOnFaded?.Invoke();
                FadeOut();
            });
        }

        private void FadeIn(Action onEnded = null)
        {
            FadeController(1, onEnded);
        }

        private void FadeOut(Action onEnded = null)
        {
            FadeController(0, onEnded);
        }

        private void FadeController(float fadeValue, Action onEnded)
        {
            //fadeImage.DOFade(fadeValue, fadeDuration).OnComplete(() => { onEnded?.Invoke(); });
        }
    }
}