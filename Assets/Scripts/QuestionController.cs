using System;
using QuestionTypes;
using Sirenix.OdinInspector;
using UnityEngine;
public class QuestionController : MonoBehaviour
{
    private event Action<IQuestionType> QuestionUpdate;
    public IQuestionType[] questions = {new TextQuestion(), new AudioQuestion(),new TextQuestion()};
    private int questionsID;
    
    //TODO temporary
    [Button]
    public void Next()
    {
        if (questionsID >= questions.Length) return;
        OnQuestionUpdate(questions[questionsID++]);
    }
    
    public void AddListener(Action<IQuestionType> action)
    {
        QuestionUpdate += action;
    }
    
    public void RemoveListener(Action<IQuestionType> action)
    {
        QuestionUpdate -= action;
    }

    public void OnQuestionUpdate(IQuestionType obj)
    {
        QuestionUpdate?.Invoke(obj);
    }
}
