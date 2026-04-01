using UnityEngine;

public class DealDamageAndDestroy : MonoBehaviour
{
    [SerializeField] private float _bulletDamage = 10f;
    private int _enemyLayer;

    private void Start()
    {
        _enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ObjectDurability>(out var durability) && collision.gameObject.layer == _enemyLayer)
        {
            durability.TakeDamage(_bulletDamage);
        }
        Destroy(gameObject);
    }
}