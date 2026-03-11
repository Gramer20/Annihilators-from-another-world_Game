using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _bulletVelocity = 150f;

    private void Start()
    {
        _rigidbody.velocity = transform.forward * _bulletVelocity;
    }
}
