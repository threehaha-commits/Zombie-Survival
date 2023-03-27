using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _damage;
    public float _speed;

    private void Start()
    {
        var lifeTime = 2.5f;
        Invoke(nameof(DestroyBullet), lifeTime);
    }

    private void DestroyBullet()
    {
        gameObject.SetActive(false);
    }
}