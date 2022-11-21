using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

public class TextMeshButton : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI text;

    public void SetText(string content)
    {
        if(text) text.text = content;
    }
    public void AddClickListener(UnityAction listener)
    {
        button.onClick.AddListener(listener);
    }
}
