using UnityEngine;

public class EnemyHealth : MonoBehaviour, IApplyDamage
{
    private Enemy _enemy;
    private EnemyDeath _death;
    private float _health;
    
    private void Start()
    {
        _death = GetComponent<EnemyDeath>();
        _enemy = GetComponent<Enemy>();
        _health = _enemy._health;
    }

    void IApplyDamage.ApplyDamage(float value)
    {
        _health -= value;
        if(_health < 0)
            _death.Death();
    }
}