using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace KevinCastejon.MoreAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyOnPrefabAttribute))]
    public class ReadOnlyOnPrefabDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var att = (ReadOnlyOnPrefabAttribute) attribute;
            var rdOnly = att.invert
                ? PrefabStageUtility.GetCurrentPrefabStage() == null
                : PrefabStageUtility.GetCurrentPrefabStage() != null;
            if (rdOnly) EditorGUI.BeginDisabledGroup(true);

            EditorGUI.PropertyField(position, property, label);

            if (rdOnly) EditorGUI.EndDisabledGroup();
        }
    }
}