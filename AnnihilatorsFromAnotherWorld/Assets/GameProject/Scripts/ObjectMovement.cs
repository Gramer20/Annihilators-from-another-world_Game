using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField, Range(0, 30)] private int _thrustEngine = 15;

    [SerializeField, Range(0, 300)] private int _rotationSpeed = 100;

    [SerializeField, Range(0, 100)] private int _maxSpeed = 50;

    [SerializeField] private float _distance = 20f;
    public float Distance => _distance;

    private GameObject _target;

    public float MaxSpeed => _maxSpeed;
    private float _yRotation = 0f;

    private void Awake()
    {
        _target = GameObject.Find("PlayerShip");
    }

    public void ShipeMoveForward(float multiplier = 1f, ForceMode mode = ForceMode.Acceleration)
    {
        if (Vector3.Distance(transform.position, _target.transform.position) > _distance)
        {
            ApplyingForce(_thrustEngine * multiplier, transform, mode);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }

    public Quaternion ShipRotation(float direction)
    {
        _yRotation += direction * _rotationSpeed * Time.deltaTime;

        Quaternion rotate = Quaternion.Euler(0f, _yRotation, 0f);

        return rotate;
    }

    private void ApplyingForce(float thrust, Transform enginePosition, ForceMode forceMode)
    {
        _rigidbody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            forceMode);
    }
}
