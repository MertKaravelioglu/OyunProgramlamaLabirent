using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Slider : MonoBehaviour
{
    public TextMeshProUGUI numberText;

    public void SetNumberText(float value)
    {
        numberText.text = value.ToString(); 
    }
}
