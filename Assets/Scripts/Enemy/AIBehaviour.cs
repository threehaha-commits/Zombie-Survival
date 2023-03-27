using System;
using System.Collections;
using UnityEngine;

public class AIBehaviour : MonoBehaviour
{
	private Enemy _enemy;
	[SerializeField] private Behaviour _behaviour;
	private Transform _player;
	private Transform _transform;
	private float _distForAttack;
	private MoveToPlayer _moveToPlayer;
	
	private void Start()
	{
		_moveToPlayer = GetComponent<MoveToPlayer>();
		_enemy = GetComponent<Enemy>();
		_distForAttack = _enemy._distForAttack;
		_transform = transform;
		_player = _enemy._player;
		StartCoroutine(CheckState());
	}

	private IEnumerator CheckState()
	{
		while (true)
		{
			var dist = (_player.position - _transform.position).magnitude;
			if (dist <= _distForAttack)
			{
				_behaviour = Behaviour.Attack;
				_moveToPlayer.EndMove();
			}
			else
			{
				_behaviour = Behaviour.Move;
				_moveToPlayer.StartMove();
			}
			yield return new WaitForSeconds(1); // Произвольное время
		}
	}
}