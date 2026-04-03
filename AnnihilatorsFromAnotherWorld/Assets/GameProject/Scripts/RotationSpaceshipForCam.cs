using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotationSpaceshipForCam : MonoBehaviour
{
    [SerializeField] private Rigidbody _shipRigidbody;
    [SerializeField] private ObjectMovement _enemyMovement;
    [SerializeField] private Transform _cam;
    [SerializeField] private Transform _target;

    [SerializeField] private int _speedRotation = 2;

    [SerializeField] private bool IsDistanceMaintained = true;
    [SerializeField] private int _distance = 20;

    void FixedUpdate()
    {
        MovingEnemySpaceship();

        Debug.Log(_shipRigidbody.angularVelocity);
    }

    private void MovingEnemySpaceship()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, _cam.rotation, _speedRotation * Time.deltaTime);

        if (IsDistanceMaintained)
        {
            if (Vector3.Distance(transform.position, _target.position) > _distance)
            {
                _enemyMovement.ShipeMoveForward();
            }
            else
            {
                _shipRigidbody.velocity = Vector3.zero;
            }
        }
        else
        {
            _enemyMovement.ShipeMoveForward();
        }
        
    }
}
