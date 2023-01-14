using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField] private float _speed;

    private Animator _animator;
    private float _idleSpeed = 0;
    private Vector3 targetVector;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetFloat(Speed, _idleSpeed);
        _animator.SetFloat(Speed, _speed);
        targetVector = transform.position + transform.right;
        transform.position = Vector3.MoveTowards(transform.position, targetVector, _speed * Time.deltaTime);
    }
}
