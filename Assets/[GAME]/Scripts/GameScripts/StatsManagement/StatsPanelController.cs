using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.PlayerManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.StatsManagement
{
    public class StatsPanelController : BaseComponent
    {
        [SerializeField]
        private Image xpFillBar;

        [SerializeField]
        private TextMeshProUGUI levelText;

        private PlayerManager _playerManager;

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