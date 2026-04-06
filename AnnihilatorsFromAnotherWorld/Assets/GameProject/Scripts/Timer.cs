using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerView;

    int _minute = 0;
    int _second = 0;

    void Update()
    {
        _second = (_second + 1) * Convert.ToInt32(Time.deltaTime);


    }
}
