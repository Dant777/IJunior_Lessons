using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputFIeldToText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ToText(string str)
    {
         _text.text = str;
    }
}
