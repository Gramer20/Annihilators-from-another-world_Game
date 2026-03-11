using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform[] _firePoints;

    [SerializeField] private GameObject _bulletPrefab;

    public void OnFire()
    {
        foreach (Transform firePoint in _firePoints)
        {
            Vector3 spawnPosition = firePoint.position;
            Quaternion bulletDirection = firePoint.rotation;
            Instantiate(_bulletPrefab, spawnPosition, bulletDirection);
        }

    }
}