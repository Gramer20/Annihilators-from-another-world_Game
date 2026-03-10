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

    public void Move(Vector3 direction)
    {
        Vector3 maximalVelocity = direction * _maxSpeed;

        Vector3 currentVelocity = _rigidbody.velocity;

        float deltaAcceleration = _acceleration * Time.fixedDeltaTime;

        currentVelocity = Vector3.MoveTowards(currentVelocity, maximalVelocity, deltaAcceleration);

        currentVelocity.y = 0f;

        _rigidbody.velocity = currentVelocity;
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
