using UnityEngine;

namespace DefaultNamespace
{
    public class ButtonController : MonoBehaviour
    {
        public GameObject buttonPrefab;

        public void PrepareButtons(int count)
        {
            while (transform.childCount < count)
            {
                Instantiate(buttonPrefab, transform);
            }

            for (int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(i < count);
            }
        }
    }
}