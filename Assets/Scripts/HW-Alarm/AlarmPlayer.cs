using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class AlarmPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _volumeCounter = 1000f;
    private float _stepVolume;
    private Alarm _alarm;

    private void Start()
    {
        _stepVolume = 1 / _volumeCounter;
        _alarm = gameObject.GetComponent<Alarm>();
    }

    public void PlaySound()
    {
        Coroutine turnUpVolumeJob = null;
        Coroutine turnDownVolumeJob = null;

        if (_alarm.IsEnabled == true)
        {
            if (turnUpVolumeJob != null)
            {
                StopCoroutine(turnUpVolumeJob);
            }

            turnDownVolumeJob = StartCoroutine(TurnDownVolume());
        }
        else
        {
            if (turnDownVolumeJob != null)
            {
                StopCoroutine(turnDownVolumeJob);
            }

            turnUpVolumeJob = StartCoroutine(TurnUpVolume());
        }
    }

    private IEnumerator TurnUpVolume()
    {
        if (_audio.isPlaying == false)
        {
            _audio.volume = _minVolume;
            _audio.Play();
        }

        for (int i = 0; i < _volumeCounter; i++)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _maxVolume, _stepVolume);
            Debug.Log(_audio.volume);

            yield return null;
        }
    }

    private IEnumerator TurnDownVolume()
    {
        for (int i = 0; i < _volumeCounter; i++)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _minVolume, _stepVolume);
            Debug.Log(_audio.volume);

            yield return null;
        }

        _audio.Stop();
    }
}
