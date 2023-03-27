using System;
using UnityEngine;

public class BulletContact : MonoBehaviour
{
    private Bullet _bullet;
    private float _damage;

    private void Start()
    {
        _bullet = GetComponent<Bullet>();
        _damage = _bullet._damage;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var applyDamage = col.gameObject.GetComponents<IApplyDamage>();
        foreach (var damage in applyDamage)
            damage.ApplyDamage(_damage);
        gameObject.SetActive(false);
    }
}