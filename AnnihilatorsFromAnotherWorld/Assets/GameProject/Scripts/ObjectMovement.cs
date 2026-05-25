using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField, Range(0, 30)] private int _thrustEngine = 15;

    [SerializeField, Range(0, 100)] private int _maxSpeed = 50;

    public float MaxSpeed => _maxSpeed;

    public void ShipeMoveForward(float multiplier = 1f, ForceMode mode = ForceMode.Acceleration)
    {
        ApplyingForce(_thrustEngine * multiplier, transform, mode);
    }

    private void ApplyingForce(float thrust, Transform enginePosition, ForceMode forceMode)
    {
        _rigidbody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            forceMode);
    }
}
