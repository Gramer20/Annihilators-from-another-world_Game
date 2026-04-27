using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnArea;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _maxEnemyCount = 3;

    private List<GameObject> EnemyCountList = new List<GameObject>();

    private WaitForSeconds wait = new WaitForSeconds(1f);
    private WaitForSeconds wait_2 = new WaitForSeconds(3f);

    private bool IsSpawning = true;


    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void FixedUpdate()
    {
        RemoveEnemy(); 
    }

    private IEnumerator Spawn()
    {
        while (IsSpawning)
        {
            while (EnemyCountList.Count < _maxEnemyCount)
            {
                GameObject enemy = Instantiate(_enemyPrefab, _spawnArea.position, RandomEnemyRotation());

                enemy.transform.parent = _spawnArea.transform;

                AddEnemy(enemy);

                yield return wait;
            }
            yield return wait_2;
        }
    }

    private void AddEnemy(GameObject enemy)
    {
        EnemyCountList.Add(enemy);
    }

    private void RemoveEnemy()
    {
        EnemyCountList.RemoveAll(enemy => enemy == null);
    }

    private Quaternion RandomEnemyRotation()
    {
        float randomY = Random.Range(-180f, 180f);

        return Quaternion.Euler(0f, randomY, 0f); 
    }
}
