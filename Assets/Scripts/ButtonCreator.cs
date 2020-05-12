using System;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    public GameObject buttonPrefab;
    [HideInInspector]public QAManager qaManager;
    public float nextQuestionDelay = 1f;//NOTE: move logic to another place
    private void Awake()
    {
        qaManager = FindObjectOfType<QAManager>();
    }

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
                    timer.SetTimer(qaManager.Next,nextQuestionDelay);//TODO block buttons when first clicked
                });
        }
    }
}