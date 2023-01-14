using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _respawnObject;
    [SerializeField] private float _respawnTime = 2f;

    private AudioSource _audio;
    private float _timeCounter = 0f;
    private GameObject _newGameObject = null;

    private void Start()
    {
        _newGameObject = Instantiate(_respawnObject, transform.position, transform.rotation);
        _audio = GetComponent<AudioSource>();
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
            _newGameObject = Instantiate(_respawnObject, transform.position, transform.rotation);
            _timeCounter = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_newGameObject != null)
            {
                Debug.Log("Play");
                _audio.PlayOneShot(_audio.clip);
            }
        }
    }
}
