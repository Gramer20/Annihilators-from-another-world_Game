using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform _spawnArea;

    [SerializeField] private GameObject _shortEnemyPrefab;
    [SerializeField] private GameObject _longEnemyPrefab;
    [SerializeField] private GameObject _bossEnemyPrefab;

    [SerializeField] private int _maxShortEnemyCount = 10;
    [SerializeField] private int _maxLongEnemyCount = 5;

    private List<GameObject> ShortEnemyCountList = new List<GameObject>();
    private List<GameObject> LongEnemyCountList = new List<GameObject>();

    private WaitForSeconds wait = new WaitForSeconds(1f);
    private WaitForSeconds wait_2 = new WaitForSeconds(3f);

    private bool IsSpawning = true;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void FixedUpdate()
    {
        RemoveEnemy(ShortEnemyCountList); 
    }

    private IEnumerator Spawn()
    {
        while (IsSpawning)
        {
            while (ShortEnemyCountList.Count < _maxShortEnemyCount || LongEnemyCountList.Count < _maxLongEnemyCount)
            {
                if (ShortEnemyCountList.Count < _maxShortEnemyCount)
                {
                    GameObject enemy = Instantiate(_shortEnemyPrefab, _spawnArea.position, RandomEnemyRotation());

                    enemy.transform.parent = _spawnArea.transform;

                    AddEnemy(ShortEnemyCountList, enemy);
                }

                if (LongEnemyCountList.Count < _maxLongEnemyCount)
                {
                    GameObject enemy = Instantiate(_longEnemyPrefab, _spawnArea.position, RandomEnemyRotation());

                    enemy.transform.parent = _spawnArea.transform;

                    AddEnemy(LongEnemyCountList, enemy);
                }

                yield return wait;
            }
            yield return wait_2;
        }
    }

    private void AddEnemy(List<GameObject> enemyList ,GameObject enemy)
    {
        enemyList.Add(enemy);
    }

    private void RemoveEnemy(List<GameObject> enemyList)
    {
        enemyList.RemoveAll(enemy => enemy == null);
    }

    private Quaternion RandomEnemyRotation()
    {
        float randomY = Random.Range(-180f, 180f);

        return Quaternion.Euler(0f, randomY, 0f); 
    }

    public void SpawnAtDeath()
    {
        GameObject enemy = Instantiate(_bossEnemyPrefab, _spawnArea.position, _spawnArea.localRotation);

        enemy.transform.parent = _spawnArea;

        SpawnEnemySpaceship(20, _longEnemyPrefab);
    }

    private void SpawnEnemySpaceship(int countEnemies, GameObject enemyPrefab)
    {
        int count = 0;


        float absolutPositionX = Mathf.Abs(_spawnArea.position.x);
        float signBeforeX = 1;

        if (absolutPositionX != 0)
            signBeforeX = _spawnArea.position.x / absolutPositionX;
            
        Debug.Log("X: " + signBeforeX);
        float spawnPositionX = absolutPositionX - 20f;


        float absolutPositionZ = Mathf.Abs(_spawnArea.position.z);
        float signBeforeZ = 1;

        if (absolutPositionZ != 0)
            signBeforeZ = _spawnArea.position.z / absolutPositionZ;

        Debug.Log("Z: " + signBeforeZ);
        float spawnPositionZ = absolutPositionZ + 10f;


        while (count <= countEnemies)
        {
            Vector3 currentSpawnVector = new Vector3(spawnPositionX * signBeforeX, 0f, spawnPositionZ * signBeforeZ);

            GameObject enemy = Instantiate(enemyPrefab, currentSpawnVector, _spawnArea.localRotation);

            enemy.transform.parent = _spawnArea;

            if (spawnPositionX >= absolutPositionX + 20f)
            {
                spawnPositionZ += 5f;
                spawnPositionX = absolutPositionX - 20f;
                count++;

                continue;
            }

            spawnPositionX += 10f;
            count++;
        }
    }
}
