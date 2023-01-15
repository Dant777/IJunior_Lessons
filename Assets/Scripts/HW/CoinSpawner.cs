using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private float _respawnTime = 2f;

    private AudioSource _audio;
    private Coin _newGameObject = null;
    private WaitForSeconds _waitForSeconds;

    private void OnEnable()
    {
        _waitForSeconds = new WaitForSeconds(_respawnTime);
    }

    private void Start()
    {
        _newGameObject = Instantiate(_template, transform.position, transform.rotation);
        _audio = GetComponent<AudioSource>();
        var timeStopJob = StartCoroutine(RespawnObject());
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

    private IEnumerator RespawnObject()
    {
        bool enable = true;

        while (enable == true)
        {
            if (_newGameObject == null)
            {
                yield return _waitForSeconds;
                _newGameObject = Instantiate(_template, transform.position, transform.rotation);
            }
        }
    }
}
