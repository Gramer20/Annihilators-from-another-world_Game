using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ObjectMovement _objectMovement;

    [SerializeField] private Rigidbody _rigidBody;

    [SerializeField] private Transform _transform;

    [SerializeField, Range(0f, 5f)] private float _accelerationMultiplier = 2f;

    [SerializeField] private float _maxAccelerationSpeed = 100f;

    private bool IsAccelerationActived = false;
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
            IsAccelerationActived = false;
        }
    }

    private void MovingSpaceship()
    {
        if (!IsAccelerationActived && _rigidBody.velocity.magnitude < _objectMovement.MaxSpeed)
        {
            //_objectMovement.ShipeMoveForward();
        }

        if (_direction != Vector2.zero)
        {
            //_objectMovement.ShipRightRotation();
            _transform.localRotation = _objectMovement.ShipRotation(_direction.y); ;

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

            _objectMovement.ShipeMoveForward(_accelerationMultiplier, ForceMode.Impulse);
        }
        else
        {
            _objectMovement.ShipeMoveForward(_accelerationMultiplier);
        }
    }
}
