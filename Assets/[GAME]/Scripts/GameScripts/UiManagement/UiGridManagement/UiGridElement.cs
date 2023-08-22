using System;
using DG.Tweening;
using Scripts.BaseGameScripts.ComponentManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.GameScripts.UiManagement.UiGridManagement
{
    public class UiGridElement : BaseComponent
    {
        public Vector2 AnchoredPos => RectTransformObj.anchoredPosition;
        public RectTransform ObjInIt { get; private set; }
        public int gridIndex;

        public void SetItem(RectTransform itemToSet, Action onAnimEnd)
        {
            ObjInIt = itemToSet;
            ObjInIt.SetParent(RectTransformObj);
            ObjInIt.DOAnchorPos(Vector2.zero, .5f).SetEase(Ease.OutCirc).OnComplete(() => { onAnimEnd?.Invoke(); });
        }
        
        public bool IsFull()
        {
            var value = TransformOfObj.childCount > 0;
            return value;
        }


        [Button]
        private void GetGridIndex()
        {
            gridIndex = TransformOfObj.GetSiblingIndex();
        }
    }
}