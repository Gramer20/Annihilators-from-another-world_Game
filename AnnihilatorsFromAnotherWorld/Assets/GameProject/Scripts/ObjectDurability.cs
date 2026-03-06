using UnityEngine;
using UnityEngine.Events;

public class ObjectDurability : MonoBehaviour
{
    [SerializeField] private UnityEvent<float, float> _onDurabilityChanged;

    [SerializeField] private UnityEvent _onDestroy;
    
    [SerializeField] private float _maxDurability = 100f;

    private float _currentDurability = 100f;

    public float MaxDurability => _maxDurability;
    public float CurrentDurability => _currentDurability;
    public bool IsAlive => _currentDurability > 0;

    public void TakeDamage(float damage)
    {
        if (IsAlive)
        {
            _currentDurability -= damage;
        }
    }
}