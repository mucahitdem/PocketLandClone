using UnityEngine;

namespace Scripts.BaseGameScripts.Managers
{
    public class EnvironmentManager : MonoBehaviour
    {
        [Header("Sky Components")]
        [SerializeField]
        private Color fogColor;

        [SerializeField]
        private Material skyMaterial;

        private void Awake()
        {
            SetSkyboxSettings();
        }

        private void SetSkyboxSettings()
        {
            RenderSettings.skybox = skyMaterial;
            RenderSettings.fogColor = fogColor;
        }
    }
}