using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private const string Speed = "Speed";

    [SerializeField] private float _speed;

    private Vector3 _targetVector;

    private void Update()
    {
        _targetVector = transform.position + transform.right;
        transform.position = Vector3.MoveTowards(transform.position, _targetVector, _speed * Time.deltaTime);
    }
}
