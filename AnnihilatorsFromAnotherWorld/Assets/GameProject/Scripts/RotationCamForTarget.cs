using UnityEngine;

public class RotationCamForTarget : MonoBehaviour
{
    private GameObject _target;

    private void Awake()
    {
        _target = GameObject.Find("PlayerShip");
    }

    void Update()
    {
        if(_target != null)
        {
            transform.LookAt(_target.transform);
        }
    }
}
