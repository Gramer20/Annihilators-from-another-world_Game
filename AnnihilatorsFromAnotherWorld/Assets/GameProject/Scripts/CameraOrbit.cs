using UnityEngine;
using UnityEngine.InputSystem;

public class CameraOrbit : MonoBehaviour
{
    private const float _startVerticalAngle = 35f;
    private const float _startHorizontalAngle = 0f;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private PlayerController _playerController;
    [SerializeField, Range(1f, 100f)] private float _defaultRadius = 5f;
    [SerializeField, Range(1f, 100f)] private float _accelerationRadius = 10f;
    [SerializeField, Range(1f, 360f)] private float _turnSpeed = 30f;

    private Vector3 currentAccelerationCamPosition;
    private Vector3 currentWithoutAccelerationCamPosition;
    float t = 0;

    private Vector2 _inputDeltaPointMove;
    private Vector2 _orbitAngles;

    private Quaternion currentCamRotation;
    private Vector3 currentCamDirection;
    private Vector3 currentCamPosition;

    private void Awake()
    {
        _orbitAngles = new Vector2(_startVerticalAngle, _startHorizontalAngle);
    }

    private void LateUpdate()
    {
        currentCamRotation = Quaternion.Euler(_orbitAngles.x, _orbitAngles.y, 0f);

        currentCamDirection = currentCamRotation * Vector3.forward;

        if (_playerTransform != null)
        {
            if (_playerController.IsAccelerationActived)
            {
                t += 3f * Time.deltaTime;
                currentCamPosition = _playerTransform.position - currentCamDirection * Mathf.Lerp(_defaultRadius, _accelerationRadius, t);
            }
            else
            {
                currentCamPosition = _playerTransform.position - currentCamDirection * _defaultRadius;
            }            
        }

        
        transform.position = currentCamPosition;
        transform.rotation = currentCamRotation;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 input = context.ReadValue<Vector2>();

            float deltaX = input.x;

            _orbitAngles.y += deltaX * _turnSpeed * Time.unscaledDeltaTime;

            _orbitAngles.y = Mathf.Repeat(_orbitAngles.y, 360f);
        }
    }
}
