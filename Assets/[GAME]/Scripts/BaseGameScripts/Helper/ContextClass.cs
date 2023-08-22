using UnityEditor;
using UnityEngine;

namespace Scripts.BaseGameScripts.Helper
{
    public static class ContextClass
    {
#if UNITY_EDITOR

        [MenuItem("CONTEXT/Component/Name Game Object")]
        private static void DoubleMass(MenuCommand command)
        {
            var body = (Component) command.context;
            Undo.RecordObject(body.gameObject, " recordObj");
            body.gameObject.name = body.GetType().Name;
        }

#endif
    }
}