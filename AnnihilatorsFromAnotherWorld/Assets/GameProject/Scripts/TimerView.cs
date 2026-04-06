using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerVeiw;

    public void Display()
    {
        _timerVeiw.text = "{0:00}";
    }
}
