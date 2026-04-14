using UnityEngine;

public class DealDamageAndDestroy : MonoBehaviour
{
    [SerializeField] private float _bulletDamage = 10f;

    private LayerMask _layerForDealDamage;

    public void SetLayerForDealDamage(LayerMask layer)
    {
        _layerForDealDamage = layer;
    }

    private void OnCollisionEnter(Collision col)
    {

        LayerMask layerMask = 1 << col.gameObject.layer;

        if (col.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            if(layerMask == _layerForDealDamage)
            {
                Debug.Log("Так точно");
            }
            durability.TakeDamage(_bulletDamage);

            Debug.Log(col.gameObject.layer + " <--> " + _layerForDealDamage.value + " ^-^");
        }

        Destroy(gameObject);
    }
}