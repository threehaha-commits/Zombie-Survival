using System;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Transform _transform;
    private Camera _camera;
    
    private void Start()
    {
        _camera = Camera.main;
        _transform = transform;
    }

    private void Update()
    {
        RotateToMouse();
    }

    private void RotateToMouse()
    {
        var mouse = _camera.ScreenToWorldPoint(Input.mousePosition);
        var difference = mouse - _transform.position;
        difference.Normalize();
        var z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.Euler(0f, 0f, z - 90);
    }
}