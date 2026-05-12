using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Shooting _shooting;
    [SerializeField] private float _shootingDistance = 25;

    private GameObject _target;

    private void Awake()
    {
        _target = GameObject.Find("PlayerShip");
    }

    private void FixedUpdate()
    {
        if(_target != null && Vector3.Distance(transform.position, _target.transform.position) <= _shootingDistance)
        {
            _shooting.ShootBullet();
        }
    }
}
