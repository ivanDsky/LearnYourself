using System;
using System.Collections.Generic;
using AnswerTypes;
using Extensions;
using GameModeTypes;
using Sirenix.OdinInspector;
using UnityEngine;
using QASpace;
using QuestionTypes;

public class QAManager : MonoBehaviour
{
    public List<QA> questions = new List<QA>{new QA(
        new TextQuestion("Question"),
        new SimpleAnswer(new List<AnswerData>{new AnswerData("Answer",true)}), 
        new GameModeDefault())};
    [Button]
    public void ConsoleWrite()
    {
        
    }

    private void Start()
    {
        questions.Shuffle();
    }
}