using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriminalInstantiate : MonoBehaviour
{
    [SerializeField] private Transform _respawnContainer;
    [SerializeField] private GameObject _respawnObject;
    [SerializeField] private float _respawnTime = 2f;

    private Transform[] _respawnPoints;
    private float _timeCounter = 0f;

    private void Start()
    {
        _respawnPoints = new Transform[_respawnContainer.childCount];

        for (int i = 0; i < _respawnContainer.childCount; i++)
        {
            _respawnPoints[i] = _respawnContainer.GetChild(i);
        }
    }

    private void Update()
    {
        _timeCounter += Time.deltaTime;

        if (_timeCounter >= _respawnTime)
        {
            int index = Random.Range(0, _respawnContainer.childCount);
            var point = _respawnPoints[index];
            Debug.Log($"{_timeCounter} респ, index {point.name}");
            GameObject newGameObject = Instantiate(_respawnObject, point.position, point.rotation);
            _timeCounter = 0f;
        }
    }
}
