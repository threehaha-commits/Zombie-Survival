using UnityEngine;

public class FireRun : MonoBehaviour
{
    public float _damage;
    public float  _spawnTime = 0.25f;
    public GameObject _fireStep;
    private Character _player;
    [HideInInspector] public Transform _playerTransform;
    
    private void Start()
    {
        _player = FindObjectOfType<Character>();
        _playerTransform = _player.transform;
    }
}