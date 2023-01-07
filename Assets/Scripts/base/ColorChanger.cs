using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer target;
    private float _runingTime;

    [SerializeField]
    private float _duration;
    
    [SerializeField]
    private Color _targetColor;

    void Start()
    {
        target = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_runingTime <= _duration)
        {
            _runingTime += Time.deltaTime;
            float normolazeRunningTime = _runingTime / _duration;

            Color newColor = new Color(_targetColor.r * normolazeRunningTime, _targetColor.g * normolazeRunningTime, _targetColor.b * normolazeRunningTime);
            target.color = newColor;
        }

    }
}
