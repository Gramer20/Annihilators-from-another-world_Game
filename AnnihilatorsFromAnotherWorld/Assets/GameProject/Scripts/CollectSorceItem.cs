using UnityEngine;

public class CollectSorceItem : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    public void AddPoint(int score)
    {
        _scoreCounter.AddScorePoint(score);
    }
}
