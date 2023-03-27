using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class Move : MonoBehaviour
{
    private Character _character;
    private float _speed;
    private Transform _transform;
    private float z;
    
    private void Start()
    {
        _character = GetComponent<Character>();
        _speed = _character._speed;
        _transform = transform;
        z = _transform.position.z;
    }

    private void Update()
    {
        KeyBoardMove();
    }

    private void KeyBoardMove()
    {
        var x = Input.GetAxis("Vertical") * _speed;
        var y = Input.GetAxis("Horizontal") * _speed;
        x *= Time.deltaTime;
        y *= Time.deltaTime;
        _transform.Translate(y, x, z);
    }
}