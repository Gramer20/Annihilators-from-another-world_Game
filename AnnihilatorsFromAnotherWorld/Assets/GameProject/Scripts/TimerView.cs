using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerView;

    public void Display(float minute, float second)
    {
        _timerView.text = string.Format("{0:00}" + ":" + "{1:00}", minute, second);
    }
}
