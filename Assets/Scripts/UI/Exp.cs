using System;
using UnityEngine;
using UnityEngine.UI;

public class Exp : MonoBehaviour
{
    [SerializeField] private int _currentExp;
    [SerializeField] private int _nextLevelExp;
    private Level _level;
    private ExpProgressBar _expProgressBar;
    
    private void Start()
    {
        _expProgressBar = GetComponent<ExpProgressBar>();
        _level = GetComponent<Level>();
    }

    public void SetExp(int value)
    {
        _currentExp += value;
        if (_currentExp == _nextLevelExp)
        {
            _level.Up();
            _currentExp = 0;
            _nextLevelExp = ExpProgressUp();
        }

        if (_currentExp > _nextLevelExp)
        {
            var minusResult = _currentExp - _nextLevelExp;
            _level.Up();
            _currentExp = 0 + minusResult;
            _nextLevelExp = ExpProgressUp();
        }
        _expProgressBar.UpdateBar(_currentExp, _nextLevelExp);
    }

    private int ExpProgressUp()
    {
        var koefA = 100;
        var koefB = 0.15f;
        var nextExp = koefA * _level.GetLevel() + koefA * _level.GetLevel() * koefB;
        return Mathf.RoundToInt(nextExp);
    }
}