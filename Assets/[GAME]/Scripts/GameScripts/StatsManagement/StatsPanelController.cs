using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.PlayerManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.StatsManagement
{
    public class StatsPanelController : BaseComponent
    {
        private PlayerManager _playerManager;

        [SerializeField]
        private TextMeshProUGUI levelText;

        [SerializeField]
        private Image xpFillBar;

        private void Start()
        {
            _playerManager = GameManager.Instance.PlayerManager;
            _playerManager.PlayerStatsManager.onXpValueChange += OnXpValueChanged;
            _playerManager.PlayerStatsManager.onLevelChanged += OnLevelChanged;
        }

        private void OnLevelChanged(int level)
        {
            levelText.text = level.ToString();
        }

        private void OnXpValueChanged(float xpValue, float xpPercentage)
        {
            DebugHelper.LogYellow("XP VAL : " + xpValue + " --- " + "PERCENTAGE : " + xpPercentage);
            xpFillBar.fillAmount = xpPercentage;
        }
    }
}