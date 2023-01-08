using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField] private float _speed;

    private Animator _animator;
    private float _idleSpeed = 0;
   
    private void Start()
    {
        _animator = GetComponent<Animator>();
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
    }
}
