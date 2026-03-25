using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Transform _leftEnginePosition;

    [SerializeField] private Transform _rightEnginePosition;

    [SerializeField, Range(0, 30)] private int _thrustEngine = 15;

    [SerializeField, Range(0, 10)] private int _rotaryThrust = 5;

    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 50f;

    public float MaxSpeed => _maxSpeed;

    public void ShipeMoveForward(float multiplier = 1f, ForceMode mode = ForceMode.Acceleration)
    {
        ApplyingForce(_thrustEngine * multiplier, _leftEnginePosition, mode);
        ApplyingForce(_thrustEngine * multiplier, _rightEnginePosition, mode);
    }


    /// <summary>
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
    }

    private void ApplyingForce(float thrust, Transform enginePosition)
    {
        _rigidbody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            ForceMode.Acceleration);
    }
    private void ApplyingForce(float thrust, Transform enginePosition, ForceMode forceMode)
    {
        _rigidbody.AddForceAtPosition(
            transform.forward * thrust,
            enginePosition.position,
            forceMode);
    }
}
