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
    public Sprite spriteImage;
    private List<QA> questions = new List<QA>();

    [SerializeField]private QuestionController questionController;
    [SerializeField]private AnswerController answerController;

    public void Adding()
    {
        questions.Add(
            new QA(
                new TextQuestion("Question #1"),
                new SimpleAnswer(new List<AnswerData> {new AnswerData("Answer", true)}),
                new GameModeDefault()
                ));
        questions.Add(
            new QA(
                new TextQuestion("Question #2"),
                new SimpleAnswer(new List<AnswerData>
                {
                    new AnswerData("First Answer", true),
                    new AnswerData("Second Answer", false),
                    new AnswerData("Third Answer", true),
                }),
                new GameModeDefault()
                ));
        questions.Add(
            new QA(
                new ImageQuestion(spriteImage), 
                new SimpleAnswer(new List<AnswerData>
                {
                    new AnswerData("First Answer",false),
                    new AnswerData("Second Answer",true),
                    new AnswerData("Third Answer",false),
                }), 
                new GameModeDefault()
                ));
    }
    
    public void Awake()
    {
        Adding();
        questions.Shuffle();
        
        foreach (var question in questions)
        {
            question.answer.Data.Shuffle();
        }
    }
    
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
}