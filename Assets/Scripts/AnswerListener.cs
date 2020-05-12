using System;
using AnswerTypes;
using UnityEngine;

public class AnswerListener : MonoBehaviour
{
    public AnswerController controller;
    public AnswerType answerType;
    public GameObject content;
    
    private void Awake()
    {
        gameObject.SetActive(false);
        controller.AddListener(Enable);
    }

    private void Enable(IAnswerType answer)
    {
        gameObject.SetActive(answerType == answer.Type);
        if (enabled)
        {
            answer.InitContent(content);
        }
    }

    private void OnDestroy()
    {
        controller.RemoveListener(Enable);
    }
}