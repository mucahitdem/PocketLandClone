using Scripts.BaseGameScripts.Component;
using UnityEngine;

namespace Scripts.GameScripts.Helpers.RectangularAreaManagement
{
    public class RectangularAreaVisualizer : BaseComponent
    {
        [SerializeField]
        private Color gizmosColor;

        [SerializeField]
        private bool disableGizmos;
        
        private RectangularAreaData rectangularAreaData;

        public void InsertData(RectangularAreaData rectangularArea)
        {
            rectangularAreaData = rectangularArea;
        }

        private void OnDrawGizmos()
        {
            if(rectangularAreaData == null || disableGizmos)
                return;
            
            Gizmos.color = gizmosColor;
            Gizmos.DrawCube(TransformOfObj.position, new Vector3(rectangularAreaData.horizontalLength,0, rectangularAreaData.verticalLength));
        }
    }
}