using System;
using System.Collections.Generic;
using Scripts.BaseGameScripts.EventManagement;
using Scripts.BaseGameScripts.Helper;
using Scripts.GameScripts.Grid;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BaseGameSystemRelatedScripts.Grid
{
    public class GridManager : EventSubscriber
    {
        public static Action gridsFilled;
        public static Func<int, GridElement> getGridElementWithIndex;
        public static Func<int, int> updateGridIndex;
        
        [SerializeField]
        private Transform gridParent;

        [SerializeField]
        private int row;
        [SerializeField]
        private float scale;
        [SerializeField]
        private int column;
        [SerializeField]
        private GridElement gridElement;
        
        [ReadOnly]
        public List<GridElement> gridElements = new List<GridElement>();

        [ReadOnly]
        public List<GridElement> gridElementsToMove = new List<GridElement>();
        
        [SerializeField]
        [ReadOnly]
        private List<Vector3> gridPositions = new List<Vector3>();
        private int _gridPositionCount;
        
        private void Awake()
        {
            SetIndices();
            GetGridPositions();
        }

        #region Subs

        public override void SubscribeEvent()
        {
            getGridElementWithIndex += GetWithIndex;
            updateGridIndex += UpdateGridIndex;
        }

        public override void UnsubscribeEvent()
        {
            getGridElementWithIndex -= GetWithIndex;
            updateGridIndex -= UpdateGridIndex;
        }

        #endregion

        private void GetGridPositions()
        {
            for (int i = 0; i < gridElementsToMove.Count; i++)
            {
                gridElementsToMove[i].positionIndex = i;
                gridPositions.Add(gridElementsToMove[i].TransformOfObj.position);
            }

            _gridPositionCount = gridElementsToMove.Count;
        }

        #region Move And Stop Grids

        private bool _upward = false;
        
        private void DoForAllGrids(Action<GridElement> actionToCall, params object[] args)
        {
            if(args.Length > 0)
                _upward = (bool) args[0];
            
            for (int i = 0; i < gridElementsToMove.Count; i++)
            {
                actionToCall?.Invoke(gridElementsToMove[i]);
            }
        }

        #region Move Grids

        public void MoveGrids(bool upward)
        {
            DoForAllGrids(MoveGrid, upward);
        }

        private void MoveGrid(GridElement currentGrid)
        {
            int posIndex = currentGrid.positionIndex;
            posIndex +=  _upward ? 1 : -1;;
                
            if (posIndex >= _gridPositionCount)
                posIndex %= _gridPositionCount;
            else if(posIndex < 0)
                posIndex = _gridPositionCount + posIndex;

            currentGrid.positionIndex = posIndex;

            currentGrid.MoveGrid(gridPositions[posIndex], posIndex);
        }

        #endregion

        #region Stop Grids

        public void StopMovementOfGrids()
        {
            DoForAllGrids(StopMovement);
        }

        private void StopMovement(GridElement grid)
        {
            grid.StopMovement();
        }

        #endregion
        
        #endregion

        private int UpdateGridIndex(int gridIndex)
        {
            if (gridIndex >= gridElementsToMove.Count)
                gridIndex -= gridElementsToMove.Count;
            else if (gridIndex < 0)
                gridIndex = (gridElementsToMove.Count) + gridIndex;
            
            return gridIndex;
        }
        private void SetIndices()
        {
            for (int i = 0; i < gridElementsToMove.Count; i++)
            {
                gridElementsToMove[i].gridIndex = i;
            }
        }
        private GridElement GetWithIndex(int index)
        {
            return gridElementsToMove[index];
        }
        public GridElement GetFirstEmptyGridElement()
        {
            for (var i = 0; i < gridElementsToMove.Count; i++)
            {
                var currentGrid = gridElementsToMove[i];
                if (!currentGrid.isFull)
                {
                    currentGrid.isFull = true;
                    //DebugHelper.LogRed("GRID ELEMENT " + i + " IS FULL ");
                    
                    if(IsAllGridsFull())
                        gridsFilled?.Invoke();
                    
                    return currentGrid;
                }
            }

            return null;
        }
        private bool IsAllGridsFull()
        {
            for (var i = 0; i < gridElementsToMove.Count; i++)
            {
                var currentGrid = gridElementsToMove[i];
                if (!currentGrid.isFull)
                    return false;
            }

            return true;
        }
        
        public void ResetAllGrids()
        {
            for (var i = 0; i < gridElements.Count; i++)
            {
                var currentGrid = gridElements[i];
                currentGrid.isFull = false;
                //DebugHelper.LogYellow("GRID ELEMENT " + i + " IS NOT FULL ");
            }
        }
        public void MakeAllGridsEmpty()
        {
            for (int i = 0; i < gridElementsToMove.Count; i++)
            {
                gridElementsToMove[i].isFull = false;
                //DebugHelper.LogYellow("GRID ELEMENT " + i + " IS NOT FULL ");
            }
        }
        private void MakeGridEmpty(int gridIndex)
        {
            gridElementsToMove[gridIndex].ResetGrid();
        }
        [Button]
        private void UpdateGridPositions()
        {
            
        }
        [Button]
        private void UpdateGridColors()
        {
            for (int i = 0; i < gridElementsToMove.Count; i++)
            {
                GridElement currentGrid = gridElementsToMove[i];
                currentGrid.ChangeImageColor();
            }
        }

        #region Create Grid

        [Button]
        public void CreateGrid()
        {
            var gridCount = 0;
            ClearGridElements();
            for (var i = 0; i < row; i++)
            for (var j = 0; j < column; j++)
            {
                var grid = Instantiate(gridElement, gridParent);
                grid.TransformOfObj.position = new Vector3(j * scale, 0, i * scale);
                grid.name = gridCount.ToString();
                gridCount++;

                if (i <= 1 || j >= column - 2)
                {
                    gridElementsToMove.Add(grid);
                    //grid.ChangeImageColor(Color.red, Color.black);
                }
                else
                {
                    gridElements.Add(grid);
                }
            }
        }

        private void ClearGridElements()
        {
            for (var i = 0; i < gridElements.Count; i++) DestroyImmediate(gridElements[i].gameObject);

            gridElements.Clear();
        }

        #endregion
    }
}