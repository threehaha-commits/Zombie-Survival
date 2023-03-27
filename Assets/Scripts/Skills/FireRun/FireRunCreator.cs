using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRunCreator : MonoBehaviour, IPeriodicallyExecutor
{
    private bool _isWork;
    private FireRun _fireRun;
    private List<GameObject> _fireSteps = new();
    
    private void Start()
    {
        _fireRun = GetComponent<FireRun>();
    }

    void IPeriodicallyExecutor.Launch()
    {
        _isWork = true;
        StartCoroutine(CreateSteps());
    }

    private GameObject Create()
    {
        return Instantiate(_fireRun._fireStep, _fireRun._playerTransform.position, Quaternion.identity);
    }
    
    void IPeriodicallyExecutor.Stop()
    {
        _isWork = false;
        foreach (var step in _fireSteps)
        {
            step.SetActive(false);
        }
    }

    private IEnumerator CreateSteps()
    {
        while (_isWork)
        {
            var step = Create();
            step.GetComponent<IContactDamage>().damage = _fireRun._damage;
            _fireSteps.Add(step);
            yield return new WaitForSeconds(_fireRun._spawnTime);
        }
    }
}