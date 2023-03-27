using System;
using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _reloadTime = 0.25f;
    public Transform _spawnPosition;
    
    private void Start()
    {
        StartCoroutine(DoFire());
    }

    private IEnumerator DoFire()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
            {
                var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var bullet = Instantiate(_bullet, _spawnPosition.position, Quaternion.identity);
                bullet.GetComponent<BulletMove>().SetBulletDirection(mouse);
                yield return new WaitForSeconds(_reloadTime);
            }

            yield return new WaitForFixedUpdate();
        }
    }
}