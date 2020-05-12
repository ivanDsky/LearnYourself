using System;
using QuestionTypes;
using Sirenix.OdinInspector;
using UnityEngine;
public class QuestionListener : MonoBehaviour
{
    public QuestionController controller;
    public QuestionType questionType;
    public GameObject content;

    private void Awake()
    {
        controller.AddListener(Enable);
        gameObject.SetActive(false);
    }

    private void Enable(IQuestionType question)
    {
        gameObject.SetActive(question.Type == questionType);
        if (gameObject.activeSelf)
        {
           question.InitContent(content);
        }
    }
    
    private void OnDestroy()
    {
        controller.RemoveListener(Enable);
    }
}
