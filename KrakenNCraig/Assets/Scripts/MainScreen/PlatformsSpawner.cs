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
    [SerializeField] private GameObject _crackedPlatform;
    [SerializeField] private GameObject _springPlatfrom;
    [SerializeField] private GameObject _spawnLine;
    [SerializeField] private GameObject _leftBorder;
    [SerializeField] private GameObject _rightBorder;
    [SerializeField] private GameObject _conteiner;
    [SerializeField] private int _platformPool;
    [SerializeField, Range(0,10)] private int _specialPlatformChance;
    [SerializeField, Range(0,10)] private int _springPlatformChance;
    
    private List<Platform> _platforms = new List<Platform>();
    private List<Platform> _crackPlatforms = new List<Platform>();
    private List<Platform> _springPlatforms = new List<Platform>();
    private float _kickOutRange = 1;
    
    public int SpecialPlatformChance => _specialPlatformChance;
    public int SpringPlatformChance => _springPlatformChance;
    
    private void OnEnable()
    {
        foreach (var platform in _platforms)
        {
            platform.DeadLineReached += ReturnPlatform;
        }
        foreach (var platform in _crackPlatforms)
        {
            platform.DeadLineReached += ReturnPlatform;
        }
        foreach (var platform in _springPlatforms)
        {
            platform.DeadLineReached += ReturnPlatform;
        }
    }

    private void OnDisable()
    {
        foreach (var platform in _platforms)
        {
            platform.DeadLineReached -= ReturnPlatform;
        }
        foreach (var platform in _crackPlatforms)
        {
            platform.DeadLineReached -= ReturnPlatform;
        }
        foreach (var platform in _springPlatforms)
        {
            platform.DeadLineReached -= ReturnPlatform;
        }
    }
    
    public void SpawnPlatform(Platform platform = null)
    {
        if (platform == null)
        {
            foreach (var pl in _platforms)
            {
                if (pl.gameObject.activeSelf == false)
                {
                    platform = pl;
                    break;
                }
            }
        }
        
        Vector3 platformPosition = new Vector3(Random.Range(_leftBorder.transform.position.x +_kickOutRange, _rightBorder.transform.position.x) -_kickOutRange, _spawnLine.transform.position.y, 0);
        
        if (platform != null)
        {
            platform.transform.position = platformPosition;
            platform.transform.SetParent(_conteiner.transform);
            platform.gameObject.SetActive(true);
        }
    }

    public void SpawnCrackPlatform()
    {
        foreach (var pl in _crackPlatforms)
        {
            if (pl.gameObject.activeSelf == false)
            {
                SpawnPlatform(pl);
                break;
            }
        }
    }

    public void SpawnSpringPlatform()
    {
        foreach (var pl in _springPlatforms)
        {
            if (pl.gameObject.activeSelf == false)
            {
                SpawnPlatform(pl);
                break;
            }
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
            FillPlatformList(_platform, _platforms);

            FillPlatformList(_springPlatfrom, _springPlatforms);
            
            FillPlatformList(_crackedPlatform, _crackPlatforms); 
        }
    }

    private void FillPlatformList(GameObject prefab, List<Platform> platformList)
    {
        GameObject platformObject = Instantiate(prefab.gameObject, _spawnLine.transform.position, Quaternion.identity);
        platformObject.transform.SetParent(_spawnLine.transform);
        Platform platform = platformObject.GetComponent<Platform>();
        platformList.Add(platform);
        platformObject.SetActive(false);
    }
    
    private void ReturnPlatform(Platform platform)
    {
        platform.gameObject.SetActive(false);
        platform.transform.parent = _spawnLine.transform;
        platform.transform.position = _spawnLine.transform.position;
    }
}
