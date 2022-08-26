using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlatformsSpawner))]
    [RequireComponent(typeof(Player))]
    public class PlayerScore : MonoBehaviour
    {
        public  UnityAction StepReached;
        public float Score => _score;

        private Player _player;
        private float _currentScore;
        private float _score = 0;
        private PlatformsSpawner _platformsSpawner;
        private List<int> _difficultyLevel;

        private void Start()
        {
            _platformsSpawner = GetComponent<PlatformsSpawner>();
            _player = GetComponent<Player>();
        }

        private void OnEnable()
        {
            StepReached += CreatePlatform;
        }

        private void OnDisable()
        {
            StepReached -= CreatePlatform;
        }

        private void Update()
        {
            _currentScore = _player.transform.position.y;
            if (_currentScore > Score)
            {
                _score = _currentScore;
            }
            
            
        }

        private void CreatePlatform()
        {
            _platformsSpawner.SpawnPlatform();
        }
    }
}