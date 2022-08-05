using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMover : MonoBehaviour
{
    [SerializeField] private GameObject _gameSpace;
    [SerializeField] private float _speed;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            MoveScreen();
        }
    }
    
    private void MoveScreen()
    {
        var transformPosition = _gameSpace.transform.position;
        transformPosition.y += _speed * Time.deltaTime;
        _gameSpace.transform.position = transformPosition;
    }
}
