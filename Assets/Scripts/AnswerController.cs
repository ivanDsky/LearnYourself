using System;
using AnswerTypes;
using Sirenix.OdinInspector;
using UnityEngine;

public class AnswerController : Controller<IAnswerType>
{
    public IAnswerType[] answers = {new SimpleAnswer(), new InputAnswer(), new SimpleAnswer()};
    public int answerID;
    
    //TODO temporary
    [Button]
    public void Next()
    {
        if (answerID >= answers.Length) return;
        OnObjectUpdate(answers[answerID++]);
    }
}
