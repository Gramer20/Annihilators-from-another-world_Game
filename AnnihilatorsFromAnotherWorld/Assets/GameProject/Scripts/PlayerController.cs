using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerShipEnergy _playerShipEnergy;

    [SerializeField] private ObjectMovement _objectMovement;

    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private Transform _transform;

    [SerializeField, Range(0, 300)] private int _rotationSpeed = 100;

    [SerializeField, Range(0f, 5f)] private float _accelerationMultiplier = 2f;

    [SerializeField] private float _maxAccelerationSpeed = 100f;

    private bool _isAccelerationActived = false;
    public bool IsAccelerationActived => _isAccelerationActived; 
    private Vector2 _direction;

    private void FixedUpdate()
    {
        MovingSpaceship();
        RotationSpaceship();
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

        if (_direction.y <= 0)
        {
            _isAccelerationActived = false;
        }
    }

    private void MovingSpaceship()
    {
        if (!_isAccelerationActived && _rigidBody.velocity.magnitude < _objectMovement.MaxSpeed)
        {
            _objectMovement.ShipeMoveForward();
        }

        if (_direction != Vector2.zero && _playerShipEnergy.Energy > 0)
        {
            if (_direction.y > 0 && _rigidBody.velocity.magnitude < _maxAccelerationSpeed)
            {
                AccelerationSpaceship();

                _playerShipEnergy.SubtractEnergyWithAcceleration();
            }
        }

        if (_direction.y <= 0)
        { 
            _playerShipEnergy.AddEnergyWithoutAcceleration();
        }
    }

    private void RotationSpaceship()
    {
        if (_direction != Vector2.zero)
        {
            float yRotation = _direction.x * _rotationSpeed * Time.deltaTime;

            transform.Rotate(0f, yRotation, 0f);
        }
    }

    private void AccelerationSpaceship()
    {
        if (!_isAccelerationActived) 
        {
            _isAccelerationActived = true;
            _objectMovement.ShipeMoveForward(_accelerationMultiplier, ForceMode.Impulse);
        }
        else
        {
            _objectMovement.ShipeMoveForward(_accelerationMultiplier);
        }
    }
}
