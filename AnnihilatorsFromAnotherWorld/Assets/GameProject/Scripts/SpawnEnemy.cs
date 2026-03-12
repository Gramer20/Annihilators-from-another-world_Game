using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _spawnArea;

    [SerializeField] private GameObject _enemyPrefab;

    private float _spawnInterval = 0.1f;
    private int _spawnCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnInterval);

        bool cicle = true;

        while (cicle)
        {
            if(_spawnCount <= 20)
            {
                Instantiate(_enemyPrefab, RandomSpawnPosition(), _spawnArea.transform.rotation);
                _spawnCount++;

                yield return waitForSeconds;
            }
            else
            {
                cicle = false;
            }
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 position = _spawnArea.transform.position;

        SphereCollider collider = _spawnArea.GetComponent<SphereCollider>();

        float radius = collider.radius;

        float randomPositionX = Random.Range(position.x - radius, position.x + radius);

        float rangeZ = Mathf.Sqrt(Mathf.Pow(radius, 2) - Mathf.Pow((randomPositionX - position.x), 2));

        float randomPositionZ = Random.Range(position.z - rangeZ, position.z + rangeZ);

        Vector3 returnPosition = new Vector3(randomPositionX, 0, randomPositionZ);

        return returnPosition;
    }
}
