using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MoreAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyOnPlayAttribute))]
    public class ReadOnlyOnPlayDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var att = (ReadOnlyOnPlayAttribute) attribute;
            var rdOnly = att.invert ? !Application.isPlaying : Application.isPlaying;
            if (rdOnly) EditorGUI.BeginDisabledGroup(true);

            EditorGUI.PropertyField(position, property, label);

            if (rdOnly) EditorGUI.EndDisabledGroup();
        }
    }
}