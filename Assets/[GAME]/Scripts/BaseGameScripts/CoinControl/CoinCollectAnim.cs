using Scripts.BaseGameScripts.PoolManagement;
using Scripts.GameScripts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.CoinControl
{
    public class CoinCollectAnim : MonoBehaviour
    {
        private Camera _camera;

        [SerializeField]
        private RectTransform coinIconOnScreen;

        [SerializeField]
        private RectTransform panelToCreateCoin;

        private Camera Camera
        {
            get
            {
                if (!_camera)
                    _camera = GameManager.Instance.MainMainCam;

                return _camera;
            }
            set => _camera = value;
        }

        [Button]
        public void Create(Vector3 createPositionOn3d, RectTransform panelToCreate = null)
        {
            var coinCreated = PoolManager.Instance.GetObjectFromPool<Coin>();

            coinCreated.TransformOfObj.parent = panelToCreate ? panelToCreate : panelToCreateCoin;
            coinCreated.TransformOfObj.position = Camera.WorldToScreenPoint(createPositionOn3d);
            coinCreated.MoveToCounter(coinIconOnScreen.position);
        }
    }
}