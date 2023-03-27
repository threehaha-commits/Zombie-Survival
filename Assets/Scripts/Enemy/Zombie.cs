using UnityEngine;

public class Zombie
{
	private Enemy _enemy;
	
	public Zombie()
	{
		_enemy = Resources.Load<Enemy>("Zombie");
	}
	
	public Enemy Create()
	{
		return Object.Instantiate(_enemy);
	}	
}