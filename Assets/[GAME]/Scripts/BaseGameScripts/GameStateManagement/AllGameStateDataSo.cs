using Scripts.GameScripts.DevHelperTools.SoCreator;
using Scripts.GameScripts.GameStateManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameScripts.GameStateManagement
{
    [CreateAssetMenu(fileName = "AllGameStateDataSo", menuName = "BaseGame/Data/AllGameStateDataSo", order = 0)]
    public class AllGameStateDataSo : BaseScriptableObject
    {
        #region Instance

        [ShowInInspector]
        [DisableInEditorMode]
        [LabelText("Static Reference")]
        [InlineButton("FindHolesDataAsset")]
        private static AllGameStateDataSo s_instance;
        public static AllGameStateDataSo Instance
        {
            get
            {
                if (!s_instance)
                {
                    s_instance = Resources.Load<AllGameStateDataSo>("AllGameStateDataSo");
                }

                return s_instance;
            }
        }

        private void FindHolesDataAsset()
        {
            if (Instance)
                return;
            Debug.LogError("Instance of type is missing in the resources folder.");
        }


        #endregion
       
        
        public BaseGameState[] AllStates => allGameStates;
        
        [SerializeField]
        private BaseGameState[] allGameStates;

        public BaseGameState GetStateWithId(string id)
        {
            for (int i = 0; i < allGameStates.Length; i++)
            {
                var currentState = allGameStates[i];
                if (currentState.StateId == id)
                {
                    return currentState;
                }
            }

            return null;
        }
    }
}