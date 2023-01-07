using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class AlarmPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;
    private float _stepVolume = 0.0002f;
    private Alarm _alarm;

    private void OnEnable()
    {
        _alarm = gameObject.GetComponent<Alarm>();
    }

    private void Update()
    {
        if (_alarm.IsEnabled == true)
        {
            if (_audio.isPlaying == false)
            {
                _audio.volume = _minVolume;
                _audio.Play();
            }

            _audio.volume = Mathf.MoveTowards(_audio.volume, _maxVolume, _stepVolume);
            Debug.Log(_audio.volume);
        }
        else
        {
            if (_audio.isPlaying == true)
            {
                _audio.volume = Mathf.MoveTowards(_audio.volume, _minVolume, _stepVolume);
                Debug.Log(_audio.volume);
                if (_audio.volume == _minVolume)
                {
                    _audio.Stop();
                   
                }
            }
        }
    }
}
