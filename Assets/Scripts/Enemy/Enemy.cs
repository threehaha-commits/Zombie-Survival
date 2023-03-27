using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int _exp;
	public float _health;
	public float _speed;
	public float _distForAttack;
	[HideInInspector] public Transform _player;
	
	private void Awake()
	{
		_player = GameObject.FindGameObjectWithTag("Player").transform;
	}
}