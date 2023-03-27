using System;
using UnityEngine;
using UnityEngine.UI;

public class ExpProgressBar : MonoBehaviour
{
    private Slider _bar;

    private void Start()
    {
        _bar = GetComponent<Slider>();
    }

    public void UpdateBar(float current, float target)
    {
        _bar.value = current / target;
    }
}