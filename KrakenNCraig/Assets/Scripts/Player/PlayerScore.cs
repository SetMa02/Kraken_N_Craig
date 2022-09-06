using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Random = System.Random;
using UnityEngine.EventSystems;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Player))]
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        
        private Player _player;
        private float _currentScore;
        private float _score = 0;
        private List<int> _difficultyLevel;
        
        public float Score => _score;
        
        private void Start()
        {
            _player = GetComponent<Player>();
        }
        
        private void Update()
        {
            _currentScore = _player.transform.position.y;
            if (_currentScore > Score)
            {
                _score = _currentScore;
                _scoreText.text = _score.ToString("0000");
            }
        }
    }
}