using System;
using QuestionTypes;
using Sirenix.OdinInspector;
using UnityEngine;
public class QuestionListener : MonoBehaviour
{
    public QuestionController controller;
    public QuestionType questionType;
    private void Start()
    {
        controller.AddListener(Enable);
        gameObject.SetActive(false);
    }

    private void Enable(IQuestionType question)
    {
        gameObject.SetActive(question.QuestionType == questionType);
    }
    
    private void OnDestroy()
    {
        controller.RemoveListener(Enable);
    }
}
