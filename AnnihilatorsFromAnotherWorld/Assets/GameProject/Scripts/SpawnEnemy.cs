using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _spawnArea;

    [SerializeField] private GameObject _enemyPrefab;

    private float _spawnInterval = 1f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());

        SphereCollider collider = _enemyPrefab.GetComponent<SphereCollider>();

        float spawnRadius = collider.radius;
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_spawnInterval);

        Instantiate(_enemyPrefab);

        yield return null;
    }
}
