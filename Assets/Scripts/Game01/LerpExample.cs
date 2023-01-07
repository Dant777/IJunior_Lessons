using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpExample : MonoBehaviour
{
    [SerializeField] private Transform _a;
    [SerializeField] private Transform _b;
    [SerializeField] private Transform _target;

    public void SetNormalizedPosition(float position)
    {
        Debug.Log(position);
       _target.position = Vector3.Lerp(_a.position, _b.position, position);

       
    }
}
