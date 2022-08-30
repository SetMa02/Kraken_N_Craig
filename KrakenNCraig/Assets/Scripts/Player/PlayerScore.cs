using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Random = System.Random;

namespace DefaultNamespace
{
    [RequireComponent(typeof(PlatformsSpawner))]
    [RequireComponent(typeof(Player))]
    public class PlayerScore : MonoBehaviour
    {
        public  UnityAction StepReached;
        public float Score => _score;

        [SerializeField]private Text _scoreText;
        private Player _player;
        private float _currentScore;
        private float _score = 0;
        private PlatformsSpawner _platformsSpawner;
        private List<int> _difficultyLevel;
        private Random _random = new Random();

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
                _scoreText.text = _score.ToString("0000");
            }
        }

        private void CreatePlatform()
        {
            int i = _random.Next(0, 10);
            
            if (_random.Next(0,10) <= _platformsSpawner.SpecialPlatformChance)
            {
                int j = _random.Next(0, 10);
                
                if (_random.Next(0,10) <= _platformsSpawner.SpringPlatformChance)
                {
                    _platformsSpawner.SpawnSpringPlatform();
                    Debug.Log("Spring");
                }
                else
                {
                    _platformsSpawner.SpawnCrackPlatform();
                    Debug.Log("Crack");
                }
            }
            _platformsSpawner.SpawnPlatform();
        }
    }
}