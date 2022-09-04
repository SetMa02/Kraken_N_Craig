using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private string _bounce = "Bounce";
    private bool _isJump = true;
    private float _jumpReadyBorder = 0.5f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Platform platform) && _isJump == true)
        {
            Jump(_jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out KrakenMovement kraken))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void FixedUpdate()
    {
       Move();
    }

    private void Move()
    {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 mouseScreenToWorld = Camera.main.ScreenToWorldPoint(mousePosition);

            if (mouseScreenToWorld.x >= 0)
            {
                Movement(_speed);
            }
            else if (mouseScreenToWorld.x < 0)
            {
                Movement(_speed * -1);
            }
        }

        if (_rigidbody.velocity.y < _jumpReadyBorder && _isJump == false)
        {
            _isJump = true;
        }
    }

    private void Movement(float moveSpeed)
    {
        var transformPosition = gameObject.transform.position;
        transformPosition.x += moveSpeed * Time.deltaTime;
        gameObject.transform.position = transformPosition;
    }

  

    public void Jump(float force)
    {
        _animator.Play(_bounce);
        _rigidbody.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        _isJump = false;
    }
}
