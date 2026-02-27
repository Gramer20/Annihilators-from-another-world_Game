using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ObjectMovement _objectMovement;

    private Vector2 _inputDirection;

    private void FixedUpdate()
    {
        if (_inputDirection  != Vector2.zero)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        Vector3 movementDirection = Vector3.forward * _inputDirection.y + Vector3.right * _inputDirection.x;

        movementDirection.Normalize();

        _objectMovement.Move(movementDirection);
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
}
