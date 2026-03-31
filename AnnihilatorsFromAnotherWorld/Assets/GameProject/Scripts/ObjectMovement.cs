using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    //[SerializeField] private Transform _leftEnginePosition;

    //[SerializeField] private Transform _rightEnginePosition;

    [SerializeField, Range(0, 30)] private int _thrustEngine = 15;

    [SerializeField, Range(0, 30)] private int _rotationSpeed = 10;

    [SerializeField, Range(0, 100)] private int _maxSpeed = 50;

    public float MaxSpeed => _maxSpeed;
    private float _yRotation = 0f;

    public void ShipeMoveForward(float multiplier = 1f, ForceMode mode = ForceMode.Acceleration)
    {
        ApplyingForce(_thrustEngine * multiplier, transform, mode);
    }

    public Quaternion ShipRotation(float direction)
    {
        _yRotation = direction * _rotationSpeed * Time.deltaTime;

        _yRotation = Mathf.Clamp(_yRotation, -90f, 90f);

        Quaternion rotate = Quaternion.Euler(0f, _yRotation, 0f);

        return rotate;
    }

    /*/// <summary>
    /// «адаЄт т€гу дл€ поворота вправо
    /// </summary>
    /// <param name="multiplier">ћножитель, предназначенный дл€ уменьшени€ т€ги при повороте. «начение задаЄтс€ от 0f до 1f</param>
    public void ShipRightRotation(float multiplier = 1f)
    {
        Mathf.Clamp(multiplier, 0.1f, 1f);

        ApplyingForce(_rotaryThrust * multiplier, _leftEnginePosition);
    }

    /// <summary>
    /// «адаЄт т€гу дл€ поворота влево
    /// </summary>
    /// <param name="multiplier">ћножитель, предназначенный дл€ уменьшени€ т€ги при повороте. «начение задаЄтс€ от 0f до 1f</param>
    public void ShipLeftRotation(float multiplier = 1f)
    {
        Mathf.Clamp(multiplier, 0.1f, 1f);

        ApplyingForce(_rotaryThrust * multiplier, _rightEnginePosition);
    }*/

    private void ApplyingForce(float thrust, Transform enginePosition, ForceMode forceMode)
    {
        _rigidbody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            forceMode);
    }
}
