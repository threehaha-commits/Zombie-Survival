using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class RotateToPlayer : MonoBehaviour
{
	private Enemy _enemy;
	private Transform _player;
	private Transform _transform;
	private void Start()
	{
		_transform = transform;
		_enemy = GetComponent<Enemy>();
		_player = _enemy._player;
	}

	private void FixedUpdate()
	{
		Rotate();
	}

	private void Rotate()
	{
		var difference = _player.position - _transform.position;
		difference.Normalize();
		var z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		_transform.rotation = Quaternion.Euler(0f, 0f, z);
	}
}