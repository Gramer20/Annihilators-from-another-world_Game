using UnityEngine;

public class DealDamageAndDestroy : MonoBehaviour
{
    [SerializeField] private float _bulletDamage = 10f;

    private int _enemyLayer;
    private int _playerLayer;
    private int _gameObjectLayer;

    private void Awake()
    {
        _enemyLayer = LayerMask.NameToLayer("Enemy");
        _playerLayer = LayerMask.NameToLayer("Player");

        _gameObjectLayer = transform.gameObject.layer;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == _enemyLayer && collision.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            durability.TakeDamage(_bulletDamage);
        }

        Destroy(gameObject);
    }
}