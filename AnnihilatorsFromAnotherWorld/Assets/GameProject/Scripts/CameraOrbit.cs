using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraOrbit : MonoBehaviour
{
    private const float _startVerticalAngle = 45f;
    private const float _startHorizontalAngle = 0f;

    [SerializeField] private Transform _playerTransform;
    [SerializeField, Range(1f, 100f)] private float _radius = 50f;
    [SerializeField, Range(1f, 360f)] private float _turnSpeed = 30f;

    private Vector2 _inputDeltaPointMove;
    private Vector2 _orbitAngles;

    private void Awake()
    {
        _orbitAngles = new Vector2(_startVerticalAngle, _startHorizontalAngle);
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(_orbitAngles.x, _orbitAngles.y, 0f);

        Vector3 direction = rotation * Vector3.forward;

        Vector3 position = _playerTransform.position - direction * _radius;

        transform.position = position;
        transform.rotation = rotation;  
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 input = context.ReadValue<Vector2>();

            float deltaX = input.x;

            _orbitAngles.y += deltaX * _turnSpeed * Time.unscaledDeltaTime;

            _orbitAngles.y = Mathf.Repeat(_orbitAngles.y, 360f);
        }
    }
}
