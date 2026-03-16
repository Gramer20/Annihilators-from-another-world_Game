using UnityEngine;

public class RotationCamForTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        transform.LookAt(target);
    }

}
