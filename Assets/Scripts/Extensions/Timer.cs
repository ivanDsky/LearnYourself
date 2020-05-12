using System;
using System.Collections;
using UnityEngine;

namespace Extensions
{
    public class Timer : MonoBehaviour
    {
        public void SetTimer(Action action,float time = 1.5f)
        {
            StartCoroutine(TimerCoroutine(time,action));
        }

        private IEnumerator TimerCoroutine(float time,Action action)
        {
            yield return new WaitForSeconds(time);
            action?.Invoke();
        }
    }
}