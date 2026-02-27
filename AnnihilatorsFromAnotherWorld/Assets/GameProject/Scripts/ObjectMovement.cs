using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField, Range(0f, 10f)] private float _acceleration = 10f;

    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 50f;

    public void Move(Vector3 direction)
    {
        Vector3 maximalVelocity = direction * _maxSpeed;

        Vector3 currentVelocity = _rigidbody.velocity;

        float deltaAcceleration = _acceleration * Time.fixedDeltaTime;

        currentVelocity = Vector3.MoveTowards(currentVelocity, maximalVelocity, deltaAcceleration);

        currentVelocity.y = 0f;

        _rigidbody.velocity = currentVelocity;
    }
}
