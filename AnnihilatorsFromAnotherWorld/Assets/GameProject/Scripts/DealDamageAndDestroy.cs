using UnityEngine;

public class DealDamageAndDestroy : MonoBehaviour
{
    [SerializeField] private float _bulletDamage = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            durability.TakeDamage(_bulletDamage);
        }
        Destroy(gameObject);
    }
}