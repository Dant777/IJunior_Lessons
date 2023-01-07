using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishTrigger : MonoBehaviour
{
    private EndPoint[] _endPoints;

    private void OnEnable()
    {
        _endPoints = gameObject.GetComponentsInChildren<EndPoint>();

        foreach (var endPoint in _endPoints)
        {
            endPoint.Reached += OnEndPointReached;
        }
    }

    private void OnDisable()
    {
        foreach (var endPoint in _endPoints)
        {
            endPoint.Reached -= OnEndPointReached;
        }
    }

    private void OnEndPointReached()
    {
        foreach (var endPoint in _endPoints)
        {
            if (endPoint.IsReached == false)
            {
                return;
            }

            Debug.Log("Finich!!!!");
        }
    }
}
