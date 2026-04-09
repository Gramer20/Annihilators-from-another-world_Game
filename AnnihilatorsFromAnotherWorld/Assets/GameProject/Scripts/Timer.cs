using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerView;

    private float _minute = 0f;
    private float _second = 0f;
    private bool IsTimerRunning = false;

    public float Min => _minute;
    public float Sec => _second;

    private void Start()
    {
        StartTimer();
        Debug.Log(string.Format("I am {0}!", "grut"));
    }

    void FixedUpdate()
    {
        if (IsTimerRunning)
        {
            _second += Time.deltaTime;

            Mathf.Clamp(_second, 0f, 60f);

            if (_second / 60 >= 1)
            {
                _minute++;
                _second = 0f;
            }


            _timerView.text = string.Format("{0:00}" + ":" + "{1:00}", _minute, _second);
        }
    }

    public void StartTimer()
    {
        IsTimerRunning = true;
    }

    public void StopTimer()
    {
        IsTimerRunning = false;
    }

    public void RestartTimer()
    {
        _minute = 0f;
        _second = 0f;
    }
}
