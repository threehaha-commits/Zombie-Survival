using System;
using UnityEngine;

public class TimeHandler : MonoBehaviour
{
        private int _minutes;
        private int _seconds;

        public string Up()
        {
                _seconds++;
                if (_seconds >= 60)
                {
                        _seconds = 0;
                        _minutes++;
                }

                var returnMinutes = _minutes < 10 ? $"0{_minutes}" : $"{_minutes}";
                var returnSeconds = _seconds < 10 ? $"0{_seconds}" : $"{_seconds}";
                return returnMinutes + ":" + returnSeconds;
        }
}