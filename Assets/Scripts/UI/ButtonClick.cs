using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void OnBtnClick()
    {
        Destroy(_text);
    }
}
