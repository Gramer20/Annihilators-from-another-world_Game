using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField, Range(0, 30)] private int _thrustEngine = 15;

    [SerializeField, Range(0, 300)] private int _rotationSpeed = 100;

    [SerializeField, Range(0, 100)] private int _maxSpeed = 50;

    public float MaxSpeed => _maxSpeed;
    private float _yRotation = 0f;

    public void ShipeMoveForward(float multiplier = 1f, ForceMode mode = ForceMode.Acceleration)
    {
        ApplyingForce(_thrustEngine * multiplier, transform, mode);
    }

    public Quaternion ShipRotation(float direction)
    {
        _yRotation += direction * _rotationSpeed * Time.deltaTime;

        Quaternion rotate = Quaternion.Euler(0f, _yRotation, 0f);

        return rotate;
    }

    private void ApplyingForce(float thrust, Transform enginePosition, ForceMode forceMode)
    {
        _rigidbody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            forceMode);
    }
}
