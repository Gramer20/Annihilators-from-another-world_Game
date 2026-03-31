using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSpaceshipForCam : MonoBehaviour
{
    [SerializeField] private Rigidbody _shipRigidbody;
    [SerializeField] private ObjectMovement _enemyMovement;
    [SerializeField] private Transform _cam;
    [SerializeField] private Transform _target;

    void FixedUpdate()
    {
        MovingEnemySpaceship();

        Debug.Log(_shipRigidbody.angularVelocity);
    }

    private void MovingEnemySpaceship()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, _cam.rotation, 2 * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target.position) > 20)
        {
            _enemyMovement.ShipeMoveForward();
        }
        else
        {
            _shipRigidbody.velocity = Vector3.zero;
        }
    }
}
