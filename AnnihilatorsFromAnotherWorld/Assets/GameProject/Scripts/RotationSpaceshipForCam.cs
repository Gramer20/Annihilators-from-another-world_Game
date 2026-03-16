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
        //MovingEnemySpaceship();
        Debug.Log(_cam.rotation);
    }

    /*private void MovingEnemySpaceship()
    {
        if (_cam.rotation.y < 0)
        {
            _enemyMovement.ShipLeftRotation();

            if (_cam.rotation.y > 0)
            {
                _shipRigidbody.velocity = Vector3.zero;
                _shipRigidbody.angularVelocity = Vector3.zero;
            }
        }

        if (_cam.rotation.y > 0)
        {
            _enemyMovement.ShipRightRotation();

            if (_cam.rotation.y < 0)
            {
                _shipRigidbody.velocity = Vector3.zero;
                _shipRigidbody.angularVelocity = Vector3.zero;
            }
        }

        if (_cam.rotation.y > -0.05 && _cam.rotation.y < 0.05 && Vector3.Distance(_target.position, _cam.position) > 10)
        {
            _enemyMovement.ShipeMoveForward();
        }
    }*/
}
