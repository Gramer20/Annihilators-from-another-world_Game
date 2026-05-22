using UnityEngine;

public class DestroyObjectWithoutDuration : MonoBehaviour
{
    [SerializeField] private GameObject _explosion;
    Vector3 explosionPosition;

    public void DestroyObject()
    {
        explosionPosition = transform.position;
        GameObject explosion = Instantiate(_explosion, explosionPosition, Quaternion.identity);

        Destroy(explosion, 1f);
        Destroy(gameObject);
    }
}
