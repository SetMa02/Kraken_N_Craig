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
       MoveScreen();
    }

    private void MoveScreen()
    { 
        if (_player.transform.position.y > _reachLine.transform.position.y && _isUpper == true) 
        {
            if (_player.transform.position.y > _gameSpace.transform.position.y + _boostPoint)
            {
                _gameSpace.transform.position = new Vector3(_gameSpace.transform.position.x,
                    _player.transform.position.y - _boostPoint, _gameSpace.transform.position.z);
            }
            else
            {
                _gameSpace.transform.position += Vector3.up * _speed * Time.deltaTime;
            }
        }
        else
        {
            _isUpper = false;
        }
    }
}
