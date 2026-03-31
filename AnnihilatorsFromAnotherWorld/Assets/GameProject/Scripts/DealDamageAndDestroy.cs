using UnityEngine;

public class DealDamageAndDestroy : MonoBehaviour
{
    [SerializeField] private float _bulletDamage = 10f;
    private int _playerLayer;

    private void Awake()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ObjectDurability>(out var durability) && collision.gameObject.layer != _playerLayer)
        {
            durability.TakeDamage(_bulletDamage);
        }
        Destroy(gameObject);
    }
}