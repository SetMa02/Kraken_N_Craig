using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class PlayerScore : MonoBehaviour
    {
        public event UnityAction StepReached;
        public float Score => _score;
        
        private Player _player;
        private float _currentScore;
        private float _score = 0;
        
        private List<int> _difficultyLevel;

        private void Update()
        {
            _currentScore = _player.transform.position.y;
            if (_currentScore > Score)
            {
                _score = _currentScore;
            }
        }
    }
}