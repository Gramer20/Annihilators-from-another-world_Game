using UnityEngine;

public class DealDamageAndDestroy : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _explosionPower = 25f;

    [SerializeField] private Rigidbody _rigidbody;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            durability.TakeDamage(_damage);
            _rigidbody.AddExplosionForce(_explosionPower, gameObject.transform.position, _explosionRadius);
        }

        Destroy(gameObject);
    }
}