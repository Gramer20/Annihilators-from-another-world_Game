using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIteme : MonoBehaviour
{
    [SerializeField] private int _score = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ScoreCounter>(out var scoreCounter))
        {
            scoreCounter.AddPoint(_score);

            Destroy(gameObject);
        }
    }
}
