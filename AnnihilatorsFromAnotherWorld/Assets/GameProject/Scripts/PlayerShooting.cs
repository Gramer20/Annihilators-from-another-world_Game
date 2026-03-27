using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform[] _firePoints;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private PlayerShootingView _shootingText;

    [SerializeField] private int _maxShots = 15;
    private int _shootingCount;

    private void Awake()
    {
        _shootingCount = _maxShots;
        DisplayShots(_shootingCount);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && _shootingCount > 0)
        {
            foreach (Transform firePoint in _firePoints)
            {
                Vector3 spawnPosition = firePoint.position;
                Quaternion bulletDirection = firePoint.rotation;
                Instantiate(_bulletPrefab, spawnPosition, bulletDirection);
            }

            RemoveShot();
        }
    }

    public void AddShot(int amount)
    {
        Mathf.Abs(amount);

        _shootingCount += amount;

        Mathf.Clamp(_shootingCount, 0, _maxShots);
        DisplayShots(_shootingCount);
    }

    public void RemoveShot(int amount = 1)
    {
        Mathf.Abs(amount);

        _shootingCount -= amount;

        Mathf.Clamp(_shootingCount, 0, _maxShots);
        DisplayShots(_shootingCount);
    }

    private void DisplayShots(int currentCountShots)
    {
        _shootingText.Display(currentCountShots, _maxShots);
    }
}