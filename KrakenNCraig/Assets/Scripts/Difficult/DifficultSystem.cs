using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlayerScore))]
    public class DifficultSystem : MonoBehaviour
    {
        public DifficultLevel CurreDifficultLevel => _currentDifficult;
        
        private List<DifficultLevel> _difficultLevels = new List<DifficultLevel>() {};
        private PlayerScore _playerScore;
        private DifficultLevel _currentDifficult;
        private float _currentStep = 0;
        private void Start()
        {
            _difficultLevels.Add(new DifficultLevel(10, 2));
            _difficultLevels.Add(new DifficultLevel(30, 2.5f));
            _difficultLevels.Add(new DifficultLevel(50, 3));
            _difficultLevels.Add(new DifficultLevel(70, 3.5f));
            _difficultLevels.Add(new DifficultLevel(100, 4));

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
                _playerScore.StepReached?.Invoke();
                _currentStep = _playerScore.Score;
            }
        }
    }
}