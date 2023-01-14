using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _respawnObject;
    [SerializeField] private float _respawnTime = 2f;

    private float _timeCounter = 0f;
    private GameObject _newGameObject = null;

    private void Start()
    {
        //GameObject newGameObject = Instantiate(_respawnObject, transform.position, transform.rotation);
    }

    private void Update()
    {
        if (_newGameObject != null)
        {
            return;
        }

        _timeCounter += Time.deltaTime;

        if (_timeCounter >= _respawnTime)
        {
            Debug.Log($"{_timeCounter} респ, index {gameObject.name}");
            _newGameObject = Instantiate(_respawnObject, transform.position, transform.rotation);
            _timeCounter = 0f;
        }
    }
}
