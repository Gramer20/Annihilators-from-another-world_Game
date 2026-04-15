using UnityEngine;

public class DealDamageAndDestroy : MonoBehaviour
{
    [SerializeField] private float _bulletDamage = 10f;

    private void OnCollisionEnter(Collision col)
    {
        LayerMask layerMask = 1 << col.gameObject.layer;

        if (col.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            durability.TakeDamage(_bulletDamage);
        }

        Destroy(gameObject);
    }
}