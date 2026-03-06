using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _leftEnginePosition;

    [SerializeField] private Transform _rightEnginePosition;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField, Range(0, 3)] private int _mainThrust = 3;

    [SerializeField, Range(0, 3)] private int _attitudeThrust = 2;

    [SerializeField, Range(0, 20)] private int _maxSpeed = 20;

    [SerializeField, Range(0, 50)] private int _accelerationMultiplier = 10;

    private float _minRotation = -30f;

    private float _maxRotation = 30f;

    private Vector2 _inputDirection;

    public Vector3 Velocity => _rigidbody.velocity;

    public bool IsInteractive { get; set; }

    private void Awake()
    {
        IsInteractive = true;
        _inputDirection = Vector2.zero;
    }

    private void Start()
    {
        _rigidbody.sleepThreshold = 0f;
    }

    private void Update()
    {
        Quaternion _correctRotation = _rigidbody.rotation;

        _correctRotation.y = Mathf.Clamp(_correctRotation.y, _minRotation, _maxRotation);

        _rigidbody.rotation = _correctRotation;
    }

    private void FixedUpdate()
    {
        Debug.Log("Speed: " + _rigidbody.velocity);

        if (IsInteractive == false) return;
        ApplyEngineForces();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _inputDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _inputDirection = Vector2.zero;
        }
    }

    private void ApplyEngineForces()
    {
        float leftThrust = CalculateThrust(_inputDirection.x, _inputDirection.y);
        float rightThrust = CalculateThrust(_inputDirection.x * -1, _inputDirection.y);

        ApplyEngineForce(leftThrust, _leftEnginePosition.position);
        ApplyEngineForce(rightThrust, _rightEnginePosition.position);
    }

    private float CalculateThrust(float horizontalInput, float verticalInput)
    {
        float thrustValue = (_mainThrust * verticalInput + _attitudeThrust * horizontalInput) * _accelerationMultiplier;

        float actualThrust = Mathf.Clamp(thrustValue, 0f, _maxSpeed);

        return actualThrust;
    }

    private void ApplyEngineForce(float thrustValue, Vector3 enginePosition)
    {
        _rigidbody.AddForceAtPosition(
        transform.forward * thrustValue,
        enginePosition,
        ForceMode.Acceleration);
    }
}

