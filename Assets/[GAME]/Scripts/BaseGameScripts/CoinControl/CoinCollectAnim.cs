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

        [SerializeField]
        private Coin coin;

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
            var parent = panelToCreate ? panelToCreate : panelToCreateCoin;
            var pos = Camera.WorldToScreenPoint(createPositionOn3d);

            
            var coinCreated = coin.Pool.PullObjFromPool<Coin>(parent, pos, Vector3.zero);

            coinCreated.MoveToCounter(coinIconOnScreen.position);
        }
    }
}