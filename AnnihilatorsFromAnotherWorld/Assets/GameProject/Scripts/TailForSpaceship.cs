using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailForSpaceship : MonoBehaviour
{

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform _tail;

    [SerializeField] private int _maxPoints = 50;

    private List<Vector3> _points;
    private List<float> _times;

    private float _nextUpdateTime;

    [SerializeField] private float _updateInterval = 0.05f;
    [SerializeField] private float _trailLifetime = 2f;

    void Start()
    {
        _lineRenderer.positionCount = 0;
        _lineRenderer.startWidth = 0.5f;
        _lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        if (Time.time >= _nextUpdateTime)
        {
            AddPoint(_tail.position);
            _nextUpdateTime = Time.time + _updateInterval;
        }
    }

    private void AddPoint(Vector3 point)
    {
        _points.Add(point);
        _times.Add(Time.time);

        while (_points.Count > _maxPoints || _times.Count > 0 && Time.time - _times[0] > _trailLifetime)
        {
            _points.RemoveAt(0);
            _times.RemoveAt(0);
        }
    }
}
