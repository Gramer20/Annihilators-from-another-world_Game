using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameTimer _timer;
    [SerializeField] private Transform[] _firePoints;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField, Range(0f, 1f)] private float _shootingInterval = 0.25f;

    private float _shootingTime;
    private float _currentShootingTime;

    private void Awake()
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
    }
     
    public void ShootBullet()
    {
        _currentShootingTime = Mathf.Repeat(_shootingTime + _shootingInterval, 60);

        Debug.Log(">>" + _currentShootingTime + " || " + "->" + _timer.Sec);

        if (_currentShootingTime <= _timer.Sec)
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
}