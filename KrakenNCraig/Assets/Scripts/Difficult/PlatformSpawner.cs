using System;
using UnityEngine;
using Random = System.Random;

namespace DefaultNamespace
{
    [RequireComponent(typeof(DifficultSystem))]
    [RequireComponent(typeof(PlatformPool))]
    public class PlatformSpawner : MonoBehaviour
    {
        private DifficultSystem _difficultSystem;
        private PlatformPool _platformPool;
        private Random _random = new Random();
        private int _fullChance = 10;

        private void OnEnable()
        {
            _difficultSystem.StepReached += CreatePlatform;
        }

        private void OnDisable()
        {
            _difficultSystem.StepReached -= CreatePlatform;
        }

        private void Awake()
        {
            _difficultSystem = GetComponent<DifficultSystem>();
            _platformPool = GetComponent<PlatformPool>();
        }

        private void CreatePlatform()
        {
            int i = _random.Next(0, _fullChance);
            
            if (_random.Next(0,_fullChance) <= _platformPool.SpecialPlatformChance)
            {
                int j = _random.Next(0, _fullChance);
                
                if (_random.Next(0,_fullChance) <= _platformPool.SpringPlatformChance)
                {
                    _platformPool.SpawnSpringPlatform();
                }
                else
                {
                    _platformPool.SpawnCrackPlatform();
                }
            }
            _platformPool.SpawnPlatform();
        }
    }
}