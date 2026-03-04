using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _rightEnginePosition;

    [SerializeField] private Transform _leftEnginePosition;

    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private float _thrustEngine = 6f;

    [SerializeField] private float _rotaryThrust = 5f;

    [SerializeField] private float _maxSpeed = 10f;

    private Vector2 _direction;

    private void Update()
    {
        ApplyingForce(_thrustEngine, _leftEnginePosition);
        ApplyingForce(_thrustEngine, _rightEnginePosition);
    }

    private void FixedUpdate()
    {
        if (_direction != Vector2.zero)
        {
            if (_direction.x > 0)
            {
                ApplyingForce(CalculateRotaryForce(_rotaryThrust), _leftEnginePosition);
            }
            if (_direction.x < 0)
            {
                ApplyingForce(CalculateRotaryForce(_rotaryThrust * -1), _rightEnginePosition);
            }
            
        }
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

    private float CalculateRotaryForce(float thrust)
    {
        float correctThrust = _direction.x * thrust;

        //correctThrust = Mathf.Clamp(correctThrust, 0, _maxSpeed);

        return correctThrust;
    }

    private void ApplyingForce(float thrust, Transform enginePosition)
    {
        _rigidBody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            ForceMode.Acceleration);
    }
}
