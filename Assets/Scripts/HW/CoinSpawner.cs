using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private float _respawnTime = 2f;

    private AudioSource _audio;
    private Coin _actualCoin = null;
    private WaitForSeconds _waitForSeconds;

    private void OnEnable()
    {
        _waitForSeconds = new WaitForSeconds(_respawnTime);
    }

    private void Start()
    {
        _actualCoin = Instantiate(_template, transform.position, transform.rotation);
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (_actualCoin != null)
            {
                Debug.Log("Play");
                _audio.PlayOneShot(_audio.clip);
                StartCoroutine(RespawnObject());
            }
        }
    }

    private IEnumerator RespawnObject()
    {
        yield return _waitForSeconds;
        _actualCoin = Instantiate(_template, transform.position, transform.rotation);
    }
}
