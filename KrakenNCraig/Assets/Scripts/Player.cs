using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Platform platform))
        {
            _animator.Play("Bounce");
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 mouseScreenToWorld = Camera.main.ScreenToWorldPoint(mousePosition);
            Debug.Log(mouseScreenToWorld.x);
            
            if (mouseScreenToWorld.x >= 0)
            {
                MoveLeft();
            }
            else if (mouseScreenToWorld.x < 0)
            {
                MoveRight();
            }
        }
    }

    private void MoveLeft()
    {
        var transformPosition = gameObject.transform.position;
        transformPosition.x += _speed * Time.deltaTime;
        gameObject.transform.position = transformPosition;
    }

    private void MoveRight()
    {
        var transformPosition = gameObject.transform.position;
        transformPosition.x -= _speed * Time.deltaTime;
        gameObject.transform.position = transformPosition;
    }
}
