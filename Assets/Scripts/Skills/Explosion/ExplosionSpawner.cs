using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExplosionSpawner : MonoBehaviour, IPeriodicallyExecutor
{
    private Explosion _explosion;
    private GameObject _currentExplosion;
    
    private void Start()
    {
        _explosion = GetComponent<Explosion>();
    }

    void IPeriodicallyExecutor.Launch()
    {
        var explosion = CreateExplosion();
        _currentExplosion = explosion;
        explosion.transform.position = SetPosition();
        explosion.GetComponent<IContactDamage>().damage = _explosion._damage;
    }

    private GameObject CreateExplosion()
    {
        var explosion = Instantiate(_explosion._explosion);
        return explosion;
    }

    private Vector2 SetPosition()
    {
        var playerPos = _explosion._playerTransform.position;
        var x = Random.Range(playerPos.x + 0.5f, playerPos.x + 2.5f);
        var y = Random.Range(playerPos.y + 0.5f, playerPos.y + 2.5f);
        return new Vector2(x, y);
    }

    void IPeriodicallyExecutor.Stop()
    {
        _currentExplosion.SetActive(false);
    }
}