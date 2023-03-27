using System;
using System.Collections.Generic;
using UnityEngine;

public class CircleOfRageRotator : MonoBehaviour
{
    private List<CircleOfRage> _circleOfRages = new();
    private CircleOfRageFabric _corFabric;
    private AttachToPlayer _attach;
    private Transform _player;
    private List<float> _angle = new();
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

    private void Start()
    {
        _corFabric = new CircleOfRageFabric();
        _attach = GetComponent<AttachToPlayer>();
        _player = _attach.transform;
        AddBullet();
    }

    public void AddBullet()
    {
        var newBullet = _corFabric.Create();
        newBullet.transform.parent = transform;
        newBullet.transform.position = Vector3.zero;
        _circleOfRages.Add(newBullet);
        _angle.Add(0);
        var radius = 3.3f / _angle.Count; //Я хз почему 3.3, но опытным путем я выяснил что это сука полный круг!
        for (int i = 0; i < _angle.Count; i++)
            _angle[i] = radius * i;
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            AddBullet();

        if (_circleOfRages.Count == 0)
            return;
        
        for (int i = 0; i < _circleOfRages.Count; i++)
        {
            _angle[i] += Time.deltaTime;
            var x = Mathf.Cos (_angle[i] * _speed) * _radius;
            var y = Mathf.Sin (_angle[i] * _speed) * _radius;
            _circleOfRages[i].transform.position = new Vector2(x, y) + (Vector2)_player.position;
        }
    }
}