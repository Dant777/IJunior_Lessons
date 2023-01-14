using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Animator _animator;
    private float _idleSpeed = 0;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _animator.SetFloat(Speed, _idleSpeed);

        if (Input.GetKey(KeyCode.A) == true)
        {
            _animator.SetFloat(Speed, _speed);
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            _animator.SetFloat(Speed, _speed);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            _rigidbody2D.velocity = Vector2.up * _jumpForce;
            Debug.Log("Jump");
        }
    }
}