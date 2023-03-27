using System;
using UnityEngine;

public class Health : MonoBehaviour, IApplyDamage
{
    private Character _character;
    private float _health;
    
    private void Start()
    {
        _character = GetComponent<Character>();
        _health = _character._health;
    }

    void IApplyDamage.ApplyDamage(float value)
    {
        _health -= value;
        if(_health < 0)
            Debug.Log(Time.time);
    }
}