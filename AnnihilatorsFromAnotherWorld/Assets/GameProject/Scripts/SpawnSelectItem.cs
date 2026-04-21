using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSelectItem : MonoBehaviour
{
    [SerializeField] private GameObject _spawnArea;
    [SerializeField] private GameObject _selectItemPrefab;
    [SerializeField] private int _maxSelectItemCount = 500;

    private float _spawnInterval = 0.005f;
    private int _spawnCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnInterval);

        while (_spawnCount <= _maxSelectItemCount)
        {
            GameObject newSelectItem = Instantiate(_selectItemPrefab, RandomSpawnPosition(), _selectItemPrefab.transform.rotation);
            newSelectItem.transform.parent = _spawnArea.transform;

            _spawnCount++;

            yield return waitForSeconds;
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        float correctXPosition = _spawnArea.transform.localScale.x / 2;
        float correctZPosition = _spawnArea.transform.localScale.z / 2;

        float randomX = Random.Range(-correctXPosition, correctXPosition);
        float randomZ = Random.Range(-correctZPosition, correctZPosition);

        return new Vector3(randomX, 0, randomZ);
    }
}
