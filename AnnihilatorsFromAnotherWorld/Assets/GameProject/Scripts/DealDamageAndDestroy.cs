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

        _gameObjectLayer = gameObject.layer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_gameObjectLayer == _playerLayer)
        {
            if (collision.gameObject.TryGetComponent<ObjectDurability>(out var durability) && collision.gameObject.layer == _enemyLayer)
            {
                durability.TakeDamage(_bulletDamage);
            }
        }
        else if (_gameObjectLayer == _enemyLayer)
        {
            if (collision.gameObject.TryGetComponent<ObjectDurability>(out var durability) && collision.gameObject.layer == _playerLayer)
            {
                durability.TakeDamage(_bulletDamage);
            }
        }


            Destroy(gameObject);
    }
}