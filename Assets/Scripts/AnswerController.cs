using System;
using AnswerTypes;
using Sirenix.OdinInspector;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    private event Action<IAnswerType> AnswerUpdate;
    public IAnswerType[] answers = {new SimpleAnswer(), new InputAnswer(), new SimpleAnswer()};
    public int answerID;
    
    //TODO temporary
    [Button]
    public void Next()
    {
        if (answerID >= answers.Length) return;
        OnAnswerUpdate(answers[answerID++]);
    }
    public void AddListener(Action<IAnswerType> action)
    {
        AnswerUpdate += action;
    }
    
    public void RemoveListener(Action<IAnswerType> action)
    {
        AnswerUpdate -= action;
    }

    public void OnAnswerUpdate(IAnswerType obj)
    {
        AnswerUpdate?.Invoke(obj);
    }
}
