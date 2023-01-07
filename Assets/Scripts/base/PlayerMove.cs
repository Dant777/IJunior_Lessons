using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private float _speed;
    private float _idleSpeed = 0;
   
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", _idleSpeed);

        if (Input.GetKey(KeyCode.A) == true)
        {
            _animator.SetFloat("Speed", _speed);
            transform.Translate(-_speed * Time.deltaTime, 0, 0);    
        }

        if (Input.GetKey(KeyCode.D) == true)
        {
            _animator.SetFloat("Speed", _speed);
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        
    }
}
