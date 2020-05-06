using UnityEngine;
using UnityEngine.UI;

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

        public void SetButtons(bool state)
        {
            foreach (Transform button in transform)
            {
                button.GetComponent<Button>().interactable = state;
            }
        }
    }
}