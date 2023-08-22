using Scripts.GameScripts.DevHelperTools.SoCreator;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.SourceManagement
{
    [CreateAssetMenu(fileName = "BaseSource", menuName = "BaseGame/Sources/BaseSource", order = 0)]
    [InlineEditor]
    public class BaseSourceDataSo : BaseScriptableObject
    {
        public BaseSourceData baseSourceData;
    }
}