using System;
using UnityEngine;

public class BulletRageMove : MonoBehaviour
{
    public float _speed { private get; set; }
    private Rigidbody2D r2d;
    
    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        r2d.velocity = transform.right * _speed * Time.fixedDeltaTime; 
    }
}