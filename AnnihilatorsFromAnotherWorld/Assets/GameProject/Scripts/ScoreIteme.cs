using UnityEngine;

public class ScoreIteme : MonoBehaviour
{
    [SerializeField] private int _score = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<CollectSorceItem>(out var collectItem))
        {
            collectItem.AddPoint(_score);

            Destroy(gameObject);
        }
    }
}
