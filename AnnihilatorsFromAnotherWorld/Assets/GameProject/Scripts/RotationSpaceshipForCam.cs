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
    }

    private void MovingEnemySpaceship()
    {
        if (_cam.localRotation.y < 0)
        {
            _enemyMovement.ShipLeftRotation();
        }

        if (_cam.localRotation.y > 0)
        {
            _enemyMovement.ShipRightRotation();
        }

        if (Vector3.Distance(_target.position, transform.position) > 10)
        {
            _enemyMovement.ShipeMoveForward();

            //_shipRigidbody.angularVelocity = Vector3.zero;
        }
        else 
        { 
            _shipRigidbody.velocity = Vector3.zero;
        }
    }
}
