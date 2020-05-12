using System;
using QuestionTypes;
using Sirenix.OdinInspector;
using UnityEngine;
public class QuestionListener : MonoBehaviour
{
    public QuestionController controller;
    public QuestionType questionType;
    public GameObject content;

    private void Start()
    {
        controller.AddListener(Enable);
        gameObject.SetActive(false);
    }

    private void Enable(IQuestionType question)
    {
        gameObject.SetActive(question.Type == questionType);
        if (enabled)
        {
           question.InitContent(content);
        }
    }
    
    private void OnDestroy()
    {
        controller.RemoveListener(Enable);
    }
}
