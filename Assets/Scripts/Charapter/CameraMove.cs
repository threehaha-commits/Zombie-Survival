using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    private Transform _transform;
    
    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position = new Vector3(player.position.x, player.position.y, _transform.position.z);
    }
}