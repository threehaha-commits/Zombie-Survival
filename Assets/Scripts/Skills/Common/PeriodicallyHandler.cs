using System;
using System.Collections;
using UnityEngine;

public class PeriodicallyHandler : MonoBehaviour, IPeriodicallyHandler
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _spawnTime;
    private IPeriodicallyExecutor _executor;
    private IPeriodicallyHandler _periodicallyHandler;
    
    float IPeriodicallyHandler.lifeTime
    {
        get => _lifeTime;
        set => _lifeTime = value;
    }

    float IPeriodicallyHandler.spawnTime
    {
        get => _spawnTime;
        set => _spawnTime = value;
    }

    IPeriodicallyExecutor IPeriodicallyHandler.executor
    {
        get => _executor;
        set => _executor = value;
    }

    private void Start()
    {
        _executor = GetComponentInChildren<IPeriodicallyExecutor>();
        _periodicallyHandler = this;
        StartCoroutine(_periodicallyHandler.Spawner());
    }

    void IPeriodicallyHandler.Upgrade(float lifeTime, float spawntime)
    {
        _lifeTime += lifeTime;
        _spawnTime += spawntime;
    }

    IEnumerator IPeriodicallyHandler.Spawner()
    {
        yield return new WaitForSeconds(_spawnTime);
        _executor.Launch();
        yield return new WaitForSeconds(_lifeTime);
        _executor.Stop();
        StartCoroutine(_periodicallyHandler.Spawner());
    }
}