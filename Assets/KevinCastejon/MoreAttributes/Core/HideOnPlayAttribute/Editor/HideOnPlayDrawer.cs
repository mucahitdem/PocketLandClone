using UnityEditor;
using UnityEngine;

namespace KevinCastejon.MoreAttributes
{
    [CustomPropertyDrawer(typeof(HideOnPlayAttribute))]
    public class HideOnPlayDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var att = (HideOnPlayAttribute) attribute;
            var hidden = att.invert ? !Application.isPlaying : Application.isPlaying;
            return hidden ? 0f : base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var att = (HideOnPlayAttribute) attribute;
            var hidden = att.invert ? !Application.isPlaying : Application.isPlaying;
            if (!hidden) EditorGUI.PropertyField(position, property, label);
        }
    }
}