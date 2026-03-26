using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousDamage : MonoBehaviour
{
    [SerializeField] private float _damagePerSecond = 20f;
    [SerializeField] private float _damageInterval = 0.1f;

    private List<ObjectDurability> _objectsInContact = new List<ObjectDurability>();

    private bool _isCoroutineRunning = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            if (!_objectsInContact.Contains(durability))
            {
                _objectsInContact.Add(durability);
            }
            if (!_isCoroutineRunning)
            {
                StartCoroutine(DamageCoroutine());

                _isCoroutineRunning = true;
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.TryGetComponent<ObjectDurability>(out var durability))
        {
            _objectsInContact.Remove(durability);
        }
    }

    private IEnumerator DamageCoroutine()
    {
        WaitForSeconds waitInterval = new WaitForSeconds(_damageInterval);

        while(_objectsInContact.Count > 0)
        {
            float damage = _damagePerSecond * _damageInterval;

            for(int i = _objectsInContact.Count - 1; i >= 0; i--)
            {
                ObjectDurability durability = _objectsInContact[i];

                if(durability != null || durability.IsAlive)
                {
                    durability.TakeDamage(damage);
                }
                else
                {
                    _objectsInContact.RemoveAt(i);
                }
            }
            yield return waitInterval;
        }
        _isCoroutineRunning = false;
    }
}
