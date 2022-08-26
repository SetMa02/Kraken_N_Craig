using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class KrakenMovement : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private DeadLine _deadLine;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _MultiplieSpeedStep;

    private float _speed;
    
    private void Start()
    {
        transform.position = _deadLine.transform.position;
        _speed = _startSpeed;
    }

    
    private void Update()
    {
        if (transform.position.y >= _deadLine.transform.position.y)
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
        }
        else if(transform.position.y < _deadLine.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, _deadLine.transform.position.y + 0.5f,
                0);
        }
    }
    
}
