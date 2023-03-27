using System;
using UnityEngine;

public class AttachToPlayer : MonoBehaviour
{
    private Character _player;
    private Transform _transform;
    private Transform _playerTransform;
    
    private void OnEnable()
    {
        _player = FindObjectOfType<Character>();
        _playerTransform = _player.transform;
        _transform = transform;
    }

    private void Update()
    {
        _transform.position = _playerTransform.position; 
    }
}