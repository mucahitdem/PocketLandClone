using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.Upgrade
{
    [Serializable]
    [InlineProperty]
    public class Ease
    {
        [SerializeField]
        [HideIf("UseCustom")]
        [HideLabel]
        [HorizontalGroup]
        public DG.Tweening.Ease baseEase;

        [SerializeField]
        [ShowIf("UseCustom")]
        [HideLabel]
        [HorizontalGroup]
        public AnimationCurve customEase = AnimationCurve.Constant(0, 10, 0f);

        [SerializeField]
        [ToggleLeft]
        [HorizontalGroup]
        [LabelWidth(1f)]
        [HideLabel]
        public bool UseCustom;

        public Tween ApplyEase(Tween t)
        {
            return ApplyEase(t, this);
        }

        public float ApplyValue(float val)
        {
            return ApplyValue(val, this);
        }

        public static float ApplyValue(float val, Ease easeData)
        {
            if (easeData.UseCustom) return easeData.customEase.Evaluate(val);

            Debug.LogError("Apply value for Tween eases is not functional. Use custom instead.");
            return -1f;
        }

        public static Tween ApplyEase(Tween t, Ease easeData)
        {
            if (easeData.UseCustom) t.SetEase(easeData.customEase);
            else t.SetEase(easeData.baseEase);
            return t;
        }
    }
}