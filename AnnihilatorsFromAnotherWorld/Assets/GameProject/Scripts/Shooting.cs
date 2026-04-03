using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform[] _firePoints;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField, Range(0f, 1f)] private float _shootingInterval = 0.25f;
    private float _shootingTime;

    private void Awake()
    {
        _shootingTime = Time.time;
    }

    public void ShootBullet()
    {
        if (_shootingTime + _shootingInterval < Time.time)
        {
            foreach (Transform firePoint in _firePoints)
            {
                Vector3 spawnPosition = firePoint.position;
                Quaternion bulletDirection = firePoint.rotation;
                Instantiate(_bulletPrefab, spawnPosition, bulletDirection);
            }
            _shootingTime = Time.time;
        }
    }
}
