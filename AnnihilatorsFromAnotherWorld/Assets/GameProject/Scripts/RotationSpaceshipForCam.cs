using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSpaceshipForCam : MonoBehaviour
{
    [SerializeField] private Rigidbody _shipRigidbody;
    [SerializeField] private ObjectMovement _enemyMovement;
    [SerializeField] private Transform _cam;
    [SerializeField] private Transform _target;

    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        MovingEnemySpaceship();

        Debug.Log(_shipRigidbody.angularVelocity);
    }

    private void MovingEnemySpaceship()
    {
        if (_cam.localRotation.y < -0.03 || _cam.localRotation.y > 0.03)
        {
            if (_cam.localRotation.y < 0 || _shipRigidbody.angularVelocity.y < 0)
            {
                _enemyMovement.ShipLeftRotation();
            }

            if (_cam.localRotation.y > 0)
            {
                _enemyMovement.ShipRightRotation();
            }
        }
        else
        {
            _shipRigidbody.angularVelocity = Vector3.zero;
        }

        if (Vector3.Distance(transform.position, _target.position) > 35)
        {
            _enemyMovement.ShipeMoveForward();
        }
        else
        {
            _shipRigidbody.velocity = Vector3.zero;
        }
    }
}
