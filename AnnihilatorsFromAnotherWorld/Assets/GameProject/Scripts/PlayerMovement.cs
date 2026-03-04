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

    private Vector2 _direction;

    private void FixedUpdate()
    {
        MovingSpaceship();
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
        }
    }

    private void MovingSpaceship()
    {
        ApplyingForce(_thrustEngine, _leftEnginePosition);
        ApplyingForce(_thrustEngine, _rightEnginePosition);

        if (_direction != Vector2.zero)
        {
            if (_direction.x > 0)
            {
                ApplyingForce(_rotaryThrust, _leftEnginePosition);
            }
            if (_direction.x < 0)
            {
                ApplyingForce(_rotaryThrust, _rightEnginePosition);
            }

        }
    }

    private void AccelerationSpaceship()
    {
        ApplyingForce();
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
