using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlayerScore))]
    public class DifficultSystem : MonoBehaviour
    {
        private List<DifficultLevel> _difficultLevels = new List<DifficultLevel>() {};
        private PlayerScore _playerScore;
        private DifficultLevel _currentDifficult;
        private float _currentStep = 0;
        public event UnityAction StepReached;
        
        public DifficultLevel CurreDifficultLevel => _currentDifficult;
        
        private void Start()
        {
            _difficultLevels.Add(new DifficultLevel(100, 2));
            _difficultLevels.Add(new DifficultLevel(200, 2.5f));
            _difficultLevels.Add(new DifficultLevel(300, 3));
            _difficultLevels.Add(new DifficultLevel(400, 3.5f));
            _difficultLevels.Add(new DifficultLevel(500, 4));

            _playerScore = GetComponent<PlayerScore>();
            _currentDifficult = _difficultLevels[0];
        }

        private void Update()
        {
            if (_playerScore.Score >= _currentDifficult.DifficultHeight)
            {
                if (_difficultLevels[_difficultLevels.Count-1] != _currentDifficult)
                {
                    _currentDifficult = _difficultLevels[_difficultLevels.IndexOf(_currentDifficult) + 1];
                }
            }
            
            if (_playerScore.Score - _currentStep >= _currentDifficult.PlatformsStep)
            {
                StepReached?.Invoke();
                _currentStep = _playerScore.Score;
            }
        }
    }
}