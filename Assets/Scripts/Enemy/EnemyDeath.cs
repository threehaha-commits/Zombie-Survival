using System;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeath : MonoBehaviour
{
    private Enemy _enemy;
    private Exp _exp;
    private UnityAction _deathAction;
    
    private void Start()
    {
        _exp = FindObjectOfType<Exp>();
        _enemy = GetComponent<Enemy>();
    }

    public void AddAction(UnityAction action)
    {
        _deathAction += action;
    }
    
    public void Death()
    {
        gameObject.SetActive(false);
        _exp.SetExp(_enemy._exp);
        _deathAction.Invoke();
    }
}