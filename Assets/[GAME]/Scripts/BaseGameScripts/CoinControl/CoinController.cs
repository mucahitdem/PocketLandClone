using DG.Tweening;
using Scripts.BaseGameScripts.CameraManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.BaseGameScripts.CoinControl
{
    public class CoinController : MonoBehaviour
    {
        private Vector2 _anchoredDiamondPos;

        [SerializeField]
        private GameObject diamond;

        [Header("Diamond Variables")]
        [SerializeField]
        private Image diamondImage;

        [HideInInspector]
        public int diamondNum;

        [SerializeField]
        private TextMeshProUGUI diamondNumText;

        private void Start()
        {
            DiamondFirstSet();
        }

        private void DiamondFirstSet()
        {
            diamondNum = PlayerPrefs.GetInt("Diamond", 0);
            diamondNumText.text = diamondNum.ToString();
            _anchoredDiamondPos = diamondImage.GetComponent<RectTransform>().anchoredPosition;
        }

        public void DiamondCollectAnim(Vector3 diamondPos)
        {
            Vector2 screenPos = CameraManager.Instance.MainCamera.WorldToScreenPoint(diamondPos);
            var clone = gameObject; //GlobalReferences.Instance.poolManager.poolObject.objToPool.PullObjFromPool();

            clone.transform.localScale = Vector3.one * .5f;

            var rectClone = clone.GetComponent<RectTransform>();
            rectClone.anchoredPosition = screenPos;

            clone.transform.parent = transform;

            rectClone.DOAnchorPos(_anchoredDiamondPos, .5f)
                .OnComplete(() =>
                {
                    clone.SetActive(false);
                    UpdateDiamondText();
                });
        }

        private void UpdateDiamondText()
        {
            diamondNum++;
            PlayerPrefs.SetInt("Diamond", diamondNum);
            diamondNumText.text = PlayerPrefs.GetInt("Diamond").ToString();
        }
    }
}