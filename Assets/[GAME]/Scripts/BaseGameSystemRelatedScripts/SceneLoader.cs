using System.Collections;
using BayatGames.SaveGameFree;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.BaseGameSystemRelatedScripts
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private bool addDelayBeforeLoad;

        [ShowIf("addDelayBeforeLoad")]
        [SerializeField]
        private float delayDuration;
        
        private int _fakeLevelNum = 1;
        private int _levelNum = 1;
        
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(addDelayBeforeLoad ? delayDuration : 0);
            LoadScene();
        }

        private void LoadScene()
        {
            _levelNum = SaveGame.Load(Defs.SAVE_KEY_LEVEL, 1);
            _fakeLevelNum = SaveGame.Load(Defs.SAVE_KEY_FAKE_LEVEL, 1);

            SceneManager.LoadScene(_levelNum);
            
            DebugHelper.LogRed("LEVEL NUM : " + _levelNum);
            DebugHelper.LogRed("FAKE LEVEL NUM : " + _fakeLevelNum);
        }
    }
}