using System;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    public GameObject buttonPrefab;

    public void InitButtons(int count)
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            //Disable button if we don't need it now
            transform.GetChild(i).gameObject.SetActive(i < count);
            transform.GetChild(i).GetComponent<ButtonController>().Reset();
            
        }

        //Instantiate buttons that we need
        for (int i = transform.childCount; i < count; ++i)
        {
            GameObject obj = Instantiate(buttonPrefab, transform);
            Timer timer = obj.GetComponent<Timer>();
            obj.GetComponent<Button>().onClick.AddListener(() =>
                {    
                    timer.SetTimer(GlobalSettings.instance.qaManager.Next,GlobalSettings.instance.nextQuestionDelay);//TODO block buttons when first clicked
                });
        }
    }
}