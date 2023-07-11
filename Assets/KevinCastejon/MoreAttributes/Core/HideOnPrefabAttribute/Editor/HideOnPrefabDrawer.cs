using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace KevinCastejon.MoreAttributes
{
    [CustomPropertyDrawer(typeof(HideOnPrefabAttribute))]
    public class HideOnPrefabDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var att = (HideOnPrefabAttribute) attribute;
            var hidden = att.invert
                ? PrefabStageUtility.GetCurrentPrefabStage() == null
                : PrefabStageUtility.GetCurrentPrefabStage() != null;
            return hidden ? 0 : EditorGUI.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var att = (HideOnPrefabAttribute) attribute;
            var hidden = att.invert
                ? PrefabStageUtility.GetCurrentPrefabStage() == null
                : PrefabStageUtility.GetCurrentPrefabStage() != null;
            if (hidden) return;
            EditorGUI.PropertyField(position, property, label);
        }
    }
}