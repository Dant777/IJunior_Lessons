using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
   
    private void Update()
    {
        var hit = Physics2D.Raycast(transform.position, transform.up);

        Debug.DrawRay(transform.position, Vector3.up * 10, Color.red);

        if (hit == true)
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
