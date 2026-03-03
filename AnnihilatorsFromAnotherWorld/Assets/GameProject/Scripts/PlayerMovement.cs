using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _rightEnginePosition;

    [SerializeField] private Transform _leftEnginePosition;

    private Vector2 _direction;

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if(_direction != Vector2.zero)
        {
            
        }
    }

    private void ApplyingForce(Transform enginePosition)
    {
        
    }
}
