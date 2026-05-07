using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //[SerializeField] private GameTimer _timer;
    [SerializeField] private Transform[] _firePoints;
    [SerializeField] private GameObject _bulletPrefab;

    //[SerializeField, Range(0f, 1f)] private float _shootingInterval = 0.25f;
    private float _shootingTime;

    [SerializeField] private WaitForSeconds _wait = new WaitForSeconds(0.25f);

    /*private void Awake()
    {
        if (_timer == null)
        {
            GameObject timer = GameObject.Find("Timer");
            _timer = timer.GetComponent<GameTimer>();
        }
    }

    private void Start()
    {
        _shootingTime = _timer.Sec;
        
    }*/

    private void Update()
    {
        StartCoroutine(ShootEnemyBullet());
    }

    /*public void ShootBullet()
    {
        if (_shootingTime + _shootingInterval > 60)
        {
            float currentShootingTime = (_shootingTime + _shootingInterval) - 60;

            if (currentShootingTime < _timer.Sec)
            {
                foreach (Transform firePoint in _firePoints)
                {
                    Vector3 spawnPosition = firePoint.position;
                    Quaternion bulletDirection = firePoint.rotation;
                    Instantiate(_bulletPrefab, spawnPosition, bulletDirection);
                }
                _shootingTime = _timer.Sec;
            }
        }
        else if (_shootingTime + _shootingInterval < _timer.Sec)
        {
            foreach (Transform firePoint in _firePoints)
            {
                Vector3 spawnPosition = firePoint.position;
                Quaternion bulletDirection = firePoint.rotation;
                Instantiate(_bulletPrefab, spawnPosition, bulletDirection);
            }
            _shootingTime = _timer.Sec;
        }
    }*/

    private IEnumerator ShootEnemyBullet()
    {
        foreach (Transform firePoint in _firePoints)
        {
            Vector3 spawnPosition = firePoint.position;
            Quaternion bulletDirection = firePoint.rotation;
            Instantiate(_bulletPrefab, spawnPosition, bulletDirection);
        }

        yield return _wait;
    }
}
