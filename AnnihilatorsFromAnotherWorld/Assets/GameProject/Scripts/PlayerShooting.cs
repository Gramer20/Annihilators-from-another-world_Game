using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;
    [SerializeField] private PlayerShootingView _shootingText;

    [SerializeField] private int _maxShots = 50;
    private int _shootingCount;

    private void Awake()
    {
        _shootingCount = _maxShots;

        DisplayShots(_shootingCount);
    }

    private void Start()
    {
        StartCoroutine(RechargeShots());
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed && _shootingCount > 0)
        {
            _shooting.ShootBullet();

            RemoveShot();
        }
    }

    private void AddShot(int amount)
    {
        Mathf.Abs(amount);

        _shootingCount += amount;

        _shootingCount = Mathf.Clamp(_shootingCount, 0, _maxShots);
        DisplayShots(_shootingCount);
    }

    public void RemoveShot(int amount = 1)
    {
        Mathf.Abs(amount);

        _shootingCount -= amount;

        _shootingCount = Mathf.Clamp(_shootingCount, 0, _maxShots);
        DisplayShots(_shootingCount);
    }

    private IEnumerator RechargeShots()
    {
        while (true)
        {
            AddShot(3);

            yield return new WaitForSeconds(2f);
        }
    }

    private void DisplayShots(int currentCountShots)
    {
        _shootingText.Display(currentCountShots, _maxShots);
    }
}