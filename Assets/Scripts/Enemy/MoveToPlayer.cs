using System;
using UnityEngine;

[RequireComponent(typeof(Enemy), typeof(Rigidbody2D))]
public class MoveToPlayer : MonoBehaviour
{
	[SerializeField] private bool _canMove;
	private Enemy _enemy;
    private float _speed;
    private float _maxSpeed;
    private Transform _player;
    private Rigidbody2D r2d;
    private Transform _transform;
    
    private void Start()
    {
	    _transform = transform;
	    r2d = GetComponent<Rigidbody2D>();
	    _enemy = GetComponent<Enemy>();
	    _player = _enemy._player;
	    _speed = _enemy._speed;
	    _maxSpeed = _speed;
    }

    public void StartMove()
    {
	    _canMove = true;
	    _speed = _maxSpeed;
    }

    public void EndMove()
    {
	    _canMove = false;
	    _speed = 0;
    }
    
    private void FixedUpdate()
    {
	    if (_canMove == false)
		    return;
	    Move();
    }

    private void Move()
    {
	    var dir = _player.position - _transform.position;
	    dir.Normalize();
	    r2d.velocity = dir * _speed * Time.fixedDeltaTime;
    }
}