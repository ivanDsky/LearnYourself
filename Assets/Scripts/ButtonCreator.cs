using UnityEngine;
public class ButtonCreator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public void InitButtons(int count)
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            //Disable button if we don't need it now
            transform.GetChild(i).gameObject.SetActive(i < count);
        }

        //Instantiate buttons that we need
        for (int i = transform.childCount; i < count; ++i)
        {
            Instantiate(buttonPrefab, transform);
        }
    }
}