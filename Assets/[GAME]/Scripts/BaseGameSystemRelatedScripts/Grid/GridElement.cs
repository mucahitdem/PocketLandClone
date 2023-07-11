using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Scripts.BaseGameScripts.Component;
using Scripts.BaseGameScripts.Helper;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.GameScripts.Grid
{
    public class GridElement : BaseComponent
    {
        [SerializeField]
        private Image outline;

        [SerializeField]
        private Image inline;
        
        public ColorContainer container;
        
        public int gridIndex;
        public bool isFull;
        public int positionIndex;
        private int _currentPosIndex;
        private bool _stopMovement;
        
        public void MoveGrid(Vector3 pos, int posIndex)
        {
            AddAndPlay(MoveTween(pos, .1f, posIndex));
        }

        private Tween MoveTween(Vector3 targetPosition, float duration, int posIndex)
        {
            return TransformOfObj.DOMove(targetPosition, duration)
                .SetEase(Ease.OutSine)
                .OnStart(() =>
                {
                    _currentPosIndex = posIndex;
                });
        }

        public void ResetGrid()
        {
            isFull = false;
        }
        
        #region Queue Tweens

        public Queue<Sequence> sequenceQueue = new Queue<Sequence>();

        private void AddAndPlay(Tween tween)
        {
            var sequence = DOTween.Sequence();
            sequence.Pause();
            sequence.Append(tween);
            sequenceQueue.Enqueue(sequence);
            
            if (sequenceQueue.Count == 1)
            {
                sequenceQueue.Peek().Play();
            }
            
            sequence.OnComplete(OnComplete);
        }
        private void OnComplete()
        {
            sequenceQueue.Dequeue();

            if (_stopMovement)
            {
                KillSequences();
                positionIndex = _currentPosIndex;
                _stopMovement = false;
                return;
            }
            
            if (sequenceQueue.Count > 0)
            {
                sequenceQueue.Peek().Play();
            }
        }

        public bool IsRunning()
        {
            // Are tween being processed?
            return (sequenceQueue.Any());
        }

        public void StopMovement()
        {
            _stopMovement = true;
        }

        private void KillSequences()
        {
            foreach (var sequence in sequenceQueue)
            {
                sequence.Kill();
            }
            sequenceQueue.Clear();
        }

        #endregion

        #region Editor Codes
        [ButtonGroup]
        public void GetImage()
        {
            Image[] imgs = GetComponentsInChildren<Image>();
            for (int i = 0; i < imgs.Length; i++)
            {
                Image currentImage = imgs[i];
                if (currentImage.name == "Image")
                    outline = currentImage;
                else
                    inline = currentImage;
                
            }
        }

        [ButtonGroup]
        public void ChangeImageColor()
        {
            outline.color = container.outlineColor;
            inline.color = container.inlineColor;
        }
        

        #endregion
    }

    [Serializable]
    public class ColorContainer
    {
        public Color outlineColor;
        public Color inlineColor;
    }
}