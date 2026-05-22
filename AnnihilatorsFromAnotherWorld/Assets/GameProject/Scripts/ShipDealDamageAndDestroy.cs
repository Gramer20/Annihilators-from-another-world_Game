using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDealDamageAndDestroy : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private float _explosionPower = 25f;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ObjectDurability _durability;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            DealDamage(durability);
        }

        _durability.KillInstantly();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            DealDamage(durability);
        }

        _durability.KillInstantly();
    }

    private void DealDamage(ObjectDurability durability)
    {
        durability.TakeDamage(_damage);
        _rigidbody.AddExplosionForce(_explosionPower, gameObject.transform.position, _explosionRadius);
    }
}
