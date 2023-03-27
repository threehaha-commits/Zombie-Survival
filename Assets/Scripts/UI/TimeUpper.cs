using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeUpper : MonoBehaviour
{
        private TimeHandler _time;
        private TMP_Text _timeText;
        
        private void Start()
        {
                _timeText = GetComponent<TMP_Text>();
                _time = GetComponent<TimeHandler>();
                StartCoroutine(PlusTime());
        }

        private IEnumerator PlusTime()
        {
                while (true)
                {
                        _timeText.text = _time.Up();
                        yield return new WaitForSeconds(1f);
                }
        }
}