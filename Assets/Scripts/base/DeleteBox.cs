using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        var objectToDelete = GameObject.FindGameObjectsWithTag("BlockToDelete");

        foreach (var item in objectToDelete)
        {
            item.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

}
