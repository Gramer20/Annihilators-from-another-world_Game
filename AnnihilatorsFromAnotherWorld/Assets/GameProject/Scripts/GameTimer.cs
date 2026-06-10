using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TimerView _timerView;

    private float _minute = 0f;
    private float _second = 0f;
    private bool _isTimerRunning = false;

    public float Min => _minute;
    public float Sec => _second;
    public bool IsTimerRunning => _isTimerRunning;

    private void Start()
    {
        StartTimer();
    }

    void FixedUpdate()
    {
        if (_isTimerRunning)
        {
            _second += Time.deltaTime;

            Mathf.Clamp(_second, 0f, 60f);

            if (_second / 60 >= 1)
            {
                _minute++;
                _second = 0f;
            }

            _timerView.Display(_minute, _second);
        }
    }

    public void StartTimer()
    {
        _isTimerRunning = true;
    }

    public void StopTimer()
    {
        _isTimerRunning = false;
    }

    public void RestartTimer()
    {
        _minute = 0f;
        _second = 0f;
    }
}
