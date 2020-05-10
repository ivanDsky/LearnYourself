using System;
using AnswerTypes;
using UnityEngine;

public class AnswerListener : MonoBehaviour
{
    public AnswerController controller;
    public AnswerTypes.AnswerType answerType;
    
    private void Start()
    {
        gameObject.SetActive(false);
        controller.AddListener(Enable);
    }

    private void Enable(IAnswerType answer)
    {
        gameObject.SetActive(answerType == answer.Type);
        Debug.Log(enabled);
    }

    private void OnDestroy()
    {
        controller.RemoveListener(Enable);
    }
}