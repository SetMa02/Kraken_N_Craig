using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMover : MonoBehaviour
{
    [SerializeField] private GameObject _gameSpace;
    [SerializeField] private GameObject _reachLine;
    [SerializeField] private float _speed;
    [SerializeField] private float _boostPoint;
    [SerializeField] private GameObject _player;
    private Vector3 _currentPosition;
    private bool _isUpper = false;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Player player))
        {
            _isUpper = true;
        }
    }
    

    private void FixedUpdate()
    {
        if (_player.transform.position.y > _reachLine.transform.position.y && _isUpper == true) 
        {
            _currentPosition = _gameSpace.transform.position;
            if (_player.transform.position.y - _gameSpace.transform.position.y >= _boostPoint)
            {
                _currentPosition = Vector3.MoveTowards(_currentPosition, _player.transform.position, _speed * Time.deltaTime * 5);
            }
            _currentPosition = Vector3.MoveTowards(_currentPosition, _player.transform.position, _speed* Time.deltaTime);
            _currentPosition.x = _gameSpace.transform.position.x;
            _currentPosition.z = -10;
            _gameSpace.transform.position = _currentPosition;
        }
        else
        {
            _isUpper = false;
        }
    }

    private void MoveScreen()
    { 
        
        /*
        var transformPosition = _gameSpace.transform.position;
        transformPosition.y += _speed * Time.deltaTime;
        _gameSpace.transform.position = transformPosition;
        */
    }
}
