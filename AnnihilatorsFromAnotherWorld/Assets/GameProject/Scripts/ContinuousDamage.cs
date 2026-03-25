using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousDamage : MonoBehaviour
{
    [SerializeField] private float _damagePerSecond = 20f;
    [SerializeField] private float _damageInterval = 0.1f;

    private List<ObjectDurability> _objectsInContact = new List<ObjectDurability>();

    private bool _isCoroutineRunning = false;


}
