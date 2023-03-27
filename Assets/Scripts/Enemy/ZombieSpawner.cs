using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ZombieSpawner : MonoBehaviour
{
	[SerializeField] private float _respawnTime = 0.5f;
	[SerializeField] private float _increaseTime = 0.0075f;
	private Zombie _zombie;
	private Transform _player;
	
	private void Start()
	{
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		_zombie = new Zombie();
		StartCoroutine(Spawn());
	}

	private void IncreaseTime()
	{
		if (_respawnTime <= 0.1f)
			return;

		_respawnTime -= _increaseTime;
	}
	
	private IEnumerator Spawn()
	{
		while (true)
		{
			var zombie = _zombie.Create();
			SetPositionToZombie(zombie.transform);
			zombie.GetComponent<EnemyDeath>().AddAction(IncreaseTime);
			yield return new WaitForSeconds(_respawnTime);
		}
	}

	private void SetPositionToZombie(Transform zombie)
	{
		var playerPos = _player.position;
		var min = 3.5f;
		var max = 4.5f;
		var x = Random.Range(0, 2);
		var y = Random.Range(0, 2);
		var posX = x == 0 ? playerPos.x - Random.Range(min, max) : playerPos.x + Random.Range(min, max);
		var posY = y == 0 ? playerPos.y - Random.Range(min, max) : playerPos.y + Random.Range(min, max);
		zombie.position = new Vector3(posX, posY, zombie.position.z);
	}
}