using System;
using System.Collections.Generic;
using AnswerTypes;
using Extensions;
using GameModeTypes;
using Sirenix.OdinInspector;
using UnityEngine;

public class AnswerController : Controller<IAnswerType>
{
    public IAnswerType[] answers = {new SimpleAnswer(new List<AnswerData>
    {
        new AnswerData("First answer",true),
        new AnswerData("Second answer",false),
        new AnswerData("Third answer",false),
    }), };
    public int answerID;
    //TODO temporary
    [Button]
    public void Next()
    {
        if (answerID >= answers.Length) return;
        OnObjectUpdate(answers[answerID++]);
    }
    
    
}
