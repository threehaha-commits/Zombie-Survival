using System;
using UnityEngine;

[RequireComponent(typeof(Bullet), typeof(Rigidbody2D))]
public class BulletMove : MonoBehaviour
{
    private Rigidbody2D r2d;
    private Bullet _bullet;
    private float _speed;
    private Vector2 _direction;
    
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        _bullet = GetComponent<Bullet>();
        _speed = _bullet._speed;
    }

    public void SetBulletDirection(Vector3 pos)
    {
        _direction = pos - transform.position;
        _direction.Normalize();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        r2d.velocity = _direction * _speed * Time.fixedDeltaTime;
    }
}