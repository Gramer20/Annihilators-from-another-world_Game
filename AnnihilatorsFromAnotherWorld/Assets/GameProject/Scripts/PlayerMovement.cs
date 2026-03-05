using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _rightEnginePosition;

    [SerializeField] private Transform _leftEnginePosition;

    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField, Range(0, 30)] private int _thrustEngine = 15;

    [SerializeField, Range(0, 10)] private int _rotaryThrust = 5;

    [SerializeField, Range(0f, 5f)] private float _accelerationMultiplier = 2f;

    [SerializeField] private float _maxSpeed = 50f;

    [SerializeField] private float _maxAccelerationSpeed = 100f;

    private bool IsAccelerationActived = false;

    private Vector2 _direction;

    private void FixedUpdate()
    {
        MovingSpaceship();
        Debug.Log("Magnitude" + _rigidBody.velocity.magnitude);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _direction = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _direction = Vector2.zero;
            IsAccelerationActived = false;
        }
    }

    private void MovingSpaceship()
    {
        if (!IsAccelerationActived && _rigidBody.velocity.magnitude < _maxSpeed)
        {
            ApplyingForce(_thrustEngine, _leftEnginePosition);
            ApplyingForce(_thrustEngine, _rightEnginePosition);
        }

        if (_direction != Vector2.zero)
        {
            if (_direction.x > 0)
            {
                ApplyingForce(_rotaryThrust, _leftEnginePosition);
            }
            else if (_direction.x < 0)
            {
                ApplyingForce(_rotaryThrust, _rightEnginePosition);
            }

            if(_direction.y > 0 && _rigidBody.velocity.magnitude < _maxAccelerationSpeed)
            {
                AccelerationSpaceship();
            }
        }
    }

    private void AccelerationSpaceship()
    {
        if (!IsAccelerationActived)
        {
            IsAccelerationActived = true;

            ApplyingForce(_thrustEngine * _accelerationMultiplier, _rightEnginePosition, ForceMode.Impulse);
            ApplyingForce(_thrustEngine * _accelerationMultiplier, _leftEnginePosition, ForceMode.Impulse);
        }
        else
        {
            ApplyingForce(_thrustEngine * _accelerationMultiplier, _rightEnginePosition);
            ApplyingForce(_thrustEngine * _accelerationMultiplier, _leftEnginePosition);
        }
    }

    private void ApplyingForce(float thrust, Transform enginePosition)
    {
        _rigidBody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            ForceMode.Acceleration);
    }
    private void ApplyingForce(float thrust, Transform enginePosition, ForceMode forceMode)
    {
        _rigidBody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            forceMode);
    }
}
