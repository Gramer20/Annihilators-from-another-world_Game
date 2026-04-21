using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _maxEnemyCount = 20;

    private float waitTime = 1f;
    private int _enemyCount = 0;


    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds wait = new WaitForSeconds(waitTime);

        while (_enemyCount < _maxEnemyCount)
        {
            GameObject enemy = Instantiate(_enemyPrefab, _spawnArea.position, _spawnArea.rotation);

            _enemyCount++;

            yield return wait;
        }

        
    }
}
