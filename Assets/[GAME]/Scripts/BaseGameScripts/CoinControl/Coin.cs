using System;
using DG.Tweening;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Pool;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.CoinControl
{
    public class Coin : BaseComponent
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private Sprite sprite;

        private void Awake()
        {
            if(sprite && image)
                image.sprite = sprite;
        }
        
        public void MoveToCounter(Vector2 targetPos, float duration = 1f)
        {
            Rect.DOMove(targetPos, duration)
                .OnComplete(() =>
                {
                    PoolManager.Instance.coinPool.pool.Push(this);
                });
        }
    }
}