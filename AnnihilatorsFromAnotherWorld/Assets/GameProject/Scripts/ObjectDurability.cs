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

    private void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        SetCurrentState(_maxDurability);
    }

    public void Restore(float amount)
    {
        if (IsAlive)
        {
            float restoreAmount = Mathf.Abs(amount);
            ChangeState(restoreAmount);
        }
    }

    public void KillInstantly()
    {
        if (IsAlive)
        {
            SetCurrentState(0);
        }
    }

    public void TakeDamage(float damage)
    {
        if (IsAlive)
        {
            _currentDurability -= damage;
        }
    }

    private void ChangeState(float amount)
    {
        float newState = _currentDurability + amount;

        if (_currentDurability != newState)
        {
            SetCurrentState(newState);
        }
    }

    private void SetCurrentState(float state)
    {
        _currentDurability = Mathf.Clamp(state, 0, _maxDurability);

        _onDurabilityChanged.Invoke(_maxDurability, _currentDurability);

        if(IsAlive == false)
        {
            _onDestroy.Invoke();
        }
    }
}