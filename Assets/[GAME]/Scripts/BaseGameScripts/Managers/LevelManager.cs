using System;
using BayatGames.SaveGameFree;
using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoad;
using Scripts.BaseGameScripts.UI;
using Scripts.GameScripts;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.BaseGameScripts.Managers
{
    public class LevelManager : MonoBehaviour, ISaveAndLoad
    {
        [Title("Private Variables")]
        private int _fakeLevelNum = 1;

        private int _levelNum = 1;
        
        private void Awake()
        {
            Application.targetFrameRate = 30;
            Load();
        }

        public void Save()
        {
            SaveGame.Save(Defs.SAVE_KEY_LEVEL, _levelNum); // replace
            SaveGame.Save(Defs.SAVE_KEY_FAKE_LEVEL, _fakeLevelNum); // replace
            
            
        }

        public void Load()
        {
            _levelNum = SaveGame.Load(Defs.SAVE_KEY_LEVEL, 1);
            _fakeLevelNum = SaveGame.Load(Defs.SAVE_KEY_FAKE_LEVEL, 1);
            
            DebugHelper.LogRed("LEVEL NUM : " + _levelNum);
            DebugHelper.LogRed("FAKE LEVEL NUM : " + _fakeLevelNum);
        }
        

        public void NextLevel()
        {
            _fakeLevelNum++;
            _levelNum++;

            if (_levelNum == SceneManager.sceneCountInBuildSettings) // loop // -1 is for loading scene
                _levelNum = 1;

            Save();

            SceneManager.LoadScene(_levelNum);
        }

        public void RetryLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            Save();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}