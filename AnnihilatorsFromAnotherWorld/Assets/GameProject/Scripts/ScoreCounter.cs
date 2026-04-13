using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private CounterView _counterView;

    private int score = 0;
    public int Score => score;

    private void Awake()
    {
        _counterView.Display(score);
    }

    public void AddScorePoint(int point)
    {
        score += point;
        _counterView.Display(score);
    }
}
