using System;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float _damage;
    public GameObject _explosion;
    private Character _player;
    [HideInInspector] public Transform _playerTransform;
    
    private void Start()
    {
        _player = FindObjectOfType<Character>();
        _playerTransform = _player.transform;
    }
}