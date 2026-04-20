using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSelectItem : MonoBehaviour
{
    [SerializeField] private GameObject _spawnArea;
    [SerializeField] private GameObject _selectItemPrefab;

    private float _spawnInterval = 0.1f;
    private int _spawnCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnInterval);

        while (_spawnCount <= 20)
        {
            Instantiate(_selectItemPrefab, RandomSpawnPosition(), _spawnArea.transform.rotation);
            _spawnCount++;

            yield return waitForSeconds;
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        float correctXPosition = _spawnArea.transform.localScale.x / 2;
        float correctZPosition = _spawnArea.transform.localScale.z / 2;

        float randomX = Random.Range(-correctXPosition + 5, correctXPosition - 5);
        float randomZ = Random.Range(-correctZPosition + 5, correctZPosition - 5);

        return new Vector3(randomX, 0, randomZ);
    }
}
