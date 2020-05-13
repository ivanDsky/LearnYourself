using System;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    public GameObject buttonPrefab;
    public int childCount;
    public void InitButtons(int count)
    {
        childCount = transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            //Disable button if we don't need it now
            transform.GetChild(i).gameObject.SetActive(i < count);
        }

        //Instantiate buttons that we need
        for (int i = childCount; i < count; ++i)
        {
            GameObject obj = Instantiate(buttonPrefab, transform);
        }
    }

    public void InitMatchButton(int count,MatchAnswerController answerController)
    {
        for (int i = 0; i < childCount; ++i)
        {
            transform.GetChild(i).GetComponent<MatchButtonController>().Reset();
        }
        //Instantiate buttons that we need
        for (int i = childCount; i < count; ++i)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            obj.GetComponent<MatchButtonController>().Sync();
            obj.GetComponent<Button>().onClick.AddListener(() =>
            {
                answerController.OnButtonClick(obj);
            });
            
        }
    }

    public void InitSimpleButton(int count)
    {
        for (int i = 0; i < childCount; ++i)
        {
            transform.GetChild(i).GetComponent<ButtonController>().Reset();
        }

        //Instantiate buttons that we need
        for (int i = childCount; i < count; ++i)
        {
            GameObject obj = transform.GetChild(i).gameObject;
            Timer timer = obj.GetComponent<Timer>();
            obj.GetComponent<Button>().onClick.AddListener(() =>
            {    
                timer.SetTimer(GlobalSettings.instance.qaManager.Next,GlobalSettings.instance.nextQuestionDelay);//TODO block buttons when first clicked
            });
        }
    }
}