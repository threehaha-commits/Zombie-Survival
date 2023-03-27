using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LaserOfDeadRotator : MonoBehaviour, IPeriodicallyExecutor
{
    private LaserOfDead _lod;
    private bool _isRotate;
    private Transform _laser;

    private void Start()
    {
        _laser = transform.GetChild(0);
        _lod = GetComponent<LaserOfDead>();
    }

    void IPeriodicallyExecutor.Stop()
    {
        _isRotate = false;
        _laser.gameObject.SetActive(_isRotate);
    }
    
    void IPeriodicallyExecutor.Launch()
    {
        SetRandomAngle();
        SetRandomDirection();
        _isRotate = true;
        _laser.gameObject.SetActive(_isRotate);
    }

    private void SetRandomAngle()
    {
        var randomAngle = Random.Range(0, 360);
        _laser.Rotate(0, 0, randomAngle);
    }

    private void SetRandomDirection()
    {
        var randomRotation = Random.Range(0, 2);
        if (randomRotation == 0)
        {
            if (_lod._speed < 0)
                _lod._speed *= -1;
            return;
        }

        _lod._speed *= -1;
    }
    
    private void FixedUpdate()
    {
        _laser.Rotate(0, 0, _lod._speed * Time.fixedDeltaTime);
    }
}