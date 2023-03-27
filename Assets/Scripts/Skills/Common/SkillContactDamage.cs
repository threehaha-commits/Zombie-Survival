using System;
using UnityEngine;

public class SkillContactDamage : MonoBehaviour, IContactDamage
{
    [SerializeField] private bool _destroy;
    [SerializeField] private float _damage;

    bool IContactDamage.destroy
    {
        get => _destroy;
        set => _destroy = value;
    }

    float IContactDamage.damage
    {
        get => _damage;
        set => _damage = value;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        DealDamage(col);
        Destroy();
    }

    private void Destroy()
    {
        if (_destroy)
            gameObject.SetActive(false);
    }

    private void DealDamage(Collider2D col)
    {
        var applyDamage = col.gameObject.GetComponents<IApplyDamage>();
        foreach (var aDamage in applyDamage)
            aDamage.ApplyDamage(_damage);
    }
}