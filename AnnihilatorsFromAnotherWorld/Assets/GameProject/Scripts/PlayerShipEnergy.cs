using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShipEnergy : MonoBehaviour
{
    [SerializeField] private UnityEvent<float, float> _onEnergyChange;
    [SerializeField] private float _maxEnergy = 100f;
    [SerializeField, Range(0f, 5f)] private float _subtractedEnergy = 1f;
    [SerializeField, Range(0f, 5f)] private float _addedEnergy = 1f;

    private WaitForSeconds wait = new WaitForSeconds(1f);
    private WaitForSeconds wait2 = new WaitForSeconds(0.5f);

    private float _energy = 0f;
    public float Energy => _energy;

    private void Awake()
    {
        _energy = _maxEnergy;
    }

    public void SubtractEnergyWithAcceleration()
    {
        StartCoroutine(SubtractEnergy());
    }

    public void AddEnergyWithoutAcceleration()
    {
        StartCoroutine(AddEnergy());
    }

    public void StopChangeEnergy()
    {
        StopCoroutine(SubtractEnergy());
        StopCoroutine(AddEnergy());
    }

    private IEnumerator SubtractEnergy()
    {
        ChangeEnergy(_subtractedEnergy * -1);

        yield return wait;
    }

    private IEnumerator AddEnergy()
    {
        ChangeEnergy(_addedEnergy);

        yield return wait2;
    }

    private void ChangeEnergy(float energy)
    {
        _energy += energy;
        _energy = Mathf.Clamp(_energy, 0f, _maxEnergy);
        _onEnergyChange.Invoke(_maxEnergy, _energy);
    }
}
