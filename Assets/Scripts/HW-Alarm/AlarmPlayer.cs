using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class AlarmPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _stepVolume;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private Alarm _alarm;
    private Coroutine _turnUpVolumeJob = null;
    private Coroutine _turnDownVolumeJob = null;

    private void Start()
    {
        _alarm = gameObject.GetComponent<Alarm>();
    }

    public void TurnUpSound()
    {
        if (_turnDownVolumeJob != null)
        {
            StopCoroutine(_turnDownVolumeJob);
        }

        _turnUpVolumeJob = StartCoroutine(TurnUpVolume());
    }

    public void TurnDownSound()
    {
        if (_turnUpVolumeJob != null)
        {
            StopCoroutine(_turnUpVolumeJob);
        }

        _turnDownVolumeJob = StartCoroutine(TurnDownVolume());
    }

    private IEnumerator TurnUpVolume()
    {
        if (_audio.isPlaying == false)
        {
            _audio.volume = _minVolume;
            _audio.Play();
        }

        while (_audio.volume < _maxVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _maxVolume, _stepVolume * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator TurnDownVolume()
    {
        while (_audio.volume > _minVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _minVolume, _stepVolume * Time.deltaTime);

            yield return null;
        }

        _audio.Stop();
        Debug.Log("_audio.Stop()");
    }
}
