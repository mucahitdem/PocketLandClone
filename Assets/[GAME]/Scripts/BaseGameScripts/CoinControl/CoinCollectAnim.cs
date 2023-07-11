using Scripts.BaseGameScripts.Pool;
using Scripts.GameScripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.CoinControl
{
    public class CoinCollectAnim : MonoBehaviour
    {
        [SerializeField]
        private RectTransform coinIconOnScreen;

        [SerializeField]
        private RectTransform panelToCreateCoin;

        private Camera _camera;
        private Camera Camera
        {
            get
            {
                if (!_camera)
                    _camera = GameManager.Instance.MainCam;
                
                return _camera;
            }
            set => _camera = value;
        }
        
        [Button]
        public void Create(Vector3 createPositionOn3d, RectTransform panelToCreate = null)
        {
            var coinCreated = PoolManager.Instance.coinPool.pool.Pull<Coin>();
            
            coinCreated.TransformOfObj.parent = panelToCreate ? panelToCreate : panelToCreateCoin;
            coinCreated.TransformOfObj.position = Camera.WorldToScreenPoint(createPositionOn3d);
            coinCreated.MoveToCounter(coinIconOnScreen.position);
        }
    }
}