using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDown : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Dropdown _dropdown;

    public void ToText(int num)
    {
        _text.text = _dropdown.options[num].text;
    }
}
