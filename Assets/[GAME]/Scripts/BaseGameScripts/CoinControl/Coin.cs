using Scripts.BaseGameScripts.ComponentManager;
using Scripts.BaseGameScripts.Pool;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.CoinControl
{
    public class Coin : BaseComponent
    {
        public BasePoolItem Pool => basePoolItem;
        
        [SerializeField]
        private Image image;

        [SerializeField]
        private Sprite sprite;

        [SerializeField]
        private BasePoolItem basePoolItem;
        
        private void Awake()
        {
            if (sprite && image)
                image.sprite = sprite;
        }

        public void MoveToCounter(Vector2 targetPos, float duration = 1f)
        {
            // Rect.DOMove(targetPos, duration)
            //     .OnComplete(() =>
            //     {
            //         PoolManager.Instance.coinPool.pool.Push(this);
            //     });
        }
    }
}