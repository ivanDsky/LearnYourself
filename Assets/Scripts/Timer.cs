using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private UnityEvent action;

        public void StartTimer()
        {
            StartCoroutine(StartTimeEnumerator());
        }

        private IEnumerator StartTimeEnumerator()
        {
            yield return new WaitForSeconds(duration);
            action?.Invoke();
        } 
    }
}