using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameObject _spawnLine;
    [SerializeField] private GameObject _leftBorder;
    [SerializeField] private GameObject _rightBorder;
    [SerializeField] private GameObject _conteiner;
    [SerializeField] private DeadLine _deadLine;
    [SerializeField] private int _platformPool;
    private List<Platform> _platforms = new List<Platform>();
    
    
    public void SpawnPlatform()
    {
        Vector3 platformPosition = new Vector3(Random.Range(_leftBorder.transform.position.x +1, _rightBorder.transform.position.x) -1, _spawnLine.transform.position.y, 0);
        _platforms[0].transform.position = platformPosition;
        _platforms[0].transform.SetParent(_conteiner.transform);
        _platforms[0].gameObject.SetActive(true);
        _platforms.RemoveAt(0);
    }
    
    private void OnEnable()
    {
        foreach (var _platform in _platforms)
        {
            _platform.DeadLineReached += ReturnPlatform;
        }
    }

    private void OnDisable()
    {
        foreach (var _platform in _platforms)
        {
            _platform.DeadLineReached -= ReturnPlatform;
        }
    }

    private void Awake()
    {
        PoolInit();
    }

    private void PoolInit()
    {
        for (int i = 0; i < _platformPool; i++)
        {
            GameObject platformObject = Instantiate(_platform.gameObject, _spawnLine.transform.position, Quaternion.identity);
            platformObject.transform.SetParent(_spawnLine.transform);
            Platform platform = platformObject.GetComponent<Platform>();
            _platforms.Add(platform);
            platformObject.SetActive(false);
        }
    }
    
    private void ReturnPlatform(Platform platform)
    {
        platform.gameObject.SetActive(false);
        platform.transform.parent = _spawnLine.transform;
        platform.transform.position = _spawnLine.transform.position;
        platform.gameObject.SetActive(false);
        _platforms.Add(platform);
    }
}
