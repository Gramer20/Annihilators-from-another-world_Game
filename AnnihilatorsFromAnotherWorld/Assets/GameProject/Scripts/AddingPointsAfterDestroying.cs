using UnityEngine;

public class AddingPointsAfterDestroying : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private int _points = 5;

    private void Start()
    {
        try
        {
            _scoreCounter = GameObject.Find("Counter").GetComponent<ScoreCounter>();
        }
        catch
        {
            Debug.Log("Counter was not found");
        }
    }

    public void AddPoint()
    {
        _scoreCounter.AddScorePoint(_points);
    }
}
