using System;
using System.Threading.Tasks;
using UnityEngine;

public class DamagePainter : MonoBehaviour, IApplyDamage
{
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void IApplyDamage.ApplyDamage(float value)
    {
        PaintSprite();
    }

    private async void PaintSprite()
    {
        _renderer.color = Color.red;
        await Task.Delay(100);
        _renderer.color = Color.white;
    }
}