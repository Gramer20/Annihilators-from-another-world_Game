using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;
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
            _shooting.ShootBullet();

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