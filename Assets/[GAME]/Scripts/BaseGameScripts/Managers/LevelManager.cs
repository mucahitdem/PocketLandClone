using Scripts.BaseGameScripts.Helper;
using Scripts.BaseGameScripts.SaveAndLoad;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.BaseGameScripts.Managers
{
    public class LevelManager : MonoBehaviour, ISaveAndLoad
    {
        private int _fakeLevelNum = 1;
        private int _levelNum = 1;

        public void Save()
        {
            // SaveGame.Save(Defs.SAVE_KEY_LEVEL, _levelNum); // replace
            // SaveGame.Save(Defs.SAVE_KEY_FAKE_LEVEL, _fakeLevelNum); // replace
        }
        public void Load()
        {
            // _levelNum = SaveGame.Load(Defs.SAVE_KEY_LEVEL, 1);
            // _fakeLevelNum = SaveGame.Load(Defs.SAVE_KEY_FAKE_LEVEL, 1);

            DebugHelper.LogRed("LEVEL NUM : " + _levelNum);
            DebugHelper.LogRed("FAKE LEVEL NUM : " + _fakeLevelNum);
        }
        private void Awake()
        {
            //Load();
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