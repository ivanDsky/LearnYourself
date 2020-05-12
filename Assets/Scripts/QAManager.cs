using System;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField]private QuestionController questionController;
    [SerializeField]private AnswerController answerController;

    public void Awake()
    {
        questions.Shuffle();
    }

    [Button]
    public void Next()
    {
        if (questions.Count <= 0) return;
        InitQuestion(questions.LastOrDefault());
        questions.RemoveAt(questions.Count - 1);
    }
    public void InitQuestion(QA question)
    {
        questionController.OnObjectUpdate(question.question);
        answerController.OnObjectUpdate(question.answer);
    }

    private void Start()
    {
        questions.Shuffle();
    }
}