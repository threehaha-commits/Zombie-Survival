using System.Collections;
using UnityEngine;

public class BulletRageCreator : MonoBehaviour, IPeriodicallyExecutor
{
    private BulletRage _bulletRage;
    private Transform _rotator;
    private BulletRageMove _bulletRageMove;
    
    private void Start()
    {
        _bulletRage = GetComponent<BulletRage>();
        _bulletRageMove = _bulletRage._bulletRageMove;
    }
    
    void IPeriodicallyExecutor.Launch()
    {
        var radius = 360 / _bulletRage._bulletCount;
        for (int i = 0; i < _bulletRage._bulletCount; i++)
        {
            var bullet = Instantiate(_bulletRageMove, transform.position, Quaternion.Euler(0, 0, radius * (i + 1)));
            bullet._speed = _bulletRage._speed;
            bullet.GetComponent<IContactDamage>().damage = _bulletRage._damage;
        }
    }

    void IPeriodicallyExecutor.Stop()
    {
        
    }
}