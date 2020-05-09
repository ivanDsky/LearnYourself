using System;
using AnswerTypes;
using UnityEngine;

public class AnswerListener : MonoBehaviour
{
    public AnswerController controller;
    public AnswerTypes.AnswerTypes answerType;
    
    private void Start()
    {
        gameObject.SetActive(false);
        controller.AddListener(Enable);
    }

    private void Enable(IAnswerType answer)
    {
        gameObject.SetActive(answerType == answer.AnswerType);
        Debug.Log(enabled);
    }

    private void OnDestroy()
    {
        controller.RemoveListener(Enable);
    }
}