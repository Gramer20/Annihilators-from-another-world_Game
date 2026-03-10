using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Transform _leftEnginePosition;

    [SerializeField] private Transform _rightEnginePosition;

    [SerializeField, Range(0, 30)] private int _thrustEngine = 15;

    [SerializeField, Range(0, 10)] private int _rotaryThrust = 5;

    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 50f;

    public float MaxSpeed => _maxSpeed;

    public void ShipeMoveForward(float multiplier = 1f, ForceMode mode = ForceMode.Acceleration)
    {
        ApplyingForce(_thrustEngine * multiplier, _leftEnginePosition, mode);
        ApplyingForce(_thrustEngine * multiplier, _rightEnginePosition, mode);
    }

    public void ShipRightRotation()
    {
        ApplyingForce(_rotaryThrust, _leftEnginePosition);
    }

    public void ShipLeftRotation()
    {
        ApplyingForce(_rotaryThrust, _rightEnginePosition);
    }

    private void ApplyingForce(float thrust, Transform enginePosition)
    {
        _rigidbody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            ForceMode.Acceleration);
    }
    private void ApplyingForce(float thrust, Transform enginePosition, ForceMode forceMode)
    {
        _rigidbody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            forceMode);
    }
}
