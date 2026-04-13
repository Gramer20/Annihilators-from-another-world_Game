using UnityEngine;

public class DealDamageAndDestroy : MonoBehaviour
{
    [SerializeField] private float _bulletDamage = 10f;

    private LayerMask _layerForDealDamage;

    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.layer == _layerForDealDamage && col.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            durability.TakeDamage(_bulletDamage);
        }

        Destroy(gameObject);
    }

    public void SetLayerForDealDamage(LayerMask layer)
    {
        //Debug.Log(layer.value);
        _layerForDealDamage = layer;
    }
}