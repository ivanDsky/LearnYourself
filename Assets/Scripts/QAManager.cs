using System.Collections.Generic;
using System.Linq;
using AnswerTypes;
using Extensions;
using GameModeTypes;
using Sirenix.OdinInspector;
using UnityEngine;
using QASpace;
using QuestionTypes;
using UnityEditor;

public class QAManager : MonoBehaviour
{
    public Sprite spriteImage;
    private List<QA> questions = new List<QA>();
    private QA current;

    [SerializeField]private QuestionController questionController;
    [SerializeField]private AnswerController answerController;
    [SerializeField]private GameObject endPanel;

    public void Adding()
    {
        questions.Add(
            new QA(
                new TextQuestion("Кто может быть лучше разработчика этой игры?"),
                new SimpleAnswer(new List<AnswerData> {new AnswerData("Никто", true)}),
                new GameModeDefault()
                ));
        questions.Add(
            new QA(
                new TextQuestion("Получит ли Ира 1000 подписчиков"),
                new SimpleAnswer(new List<AnswerData>
                {
                    new AnswerData("Конечно получит", true),
                    new AnswerData("Ха-ха, нет конечно", false),
                    new AnswerData("Если сильно постарается, то получит", true),
                }),
                new GameModeDefault()
                ));
        questions.Add(
            new QA(
                new ImageQuestion(spriteImage), 
                new InputAnswer(new AnswerData("Это картинка",true)), 
                new GameModeDefault()
                ));
        questions.Add(
            new QA(
                new TextQuestion("Тут надо будет соеденить вопрос с ответом"), 
                new MatchAnswer(
                    new List<AnswerData>
                    {
                        new AnswerData("Первый вопрос"),
                        new AnswerData("Второй вопрос"),
                        new AnswerData("Третий вопрос"),
                        new AnswerData("А это вообще вопрос?"),
                    }, 
                    new List<AnswerData>
                    {
                        new AnswerData("Первый ответ"),
                        new AnswerData("Второй ответ"),
                        new AnswerData("Третий ответ"),
                    }
                    ), 
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
        GlobalSettings.instance.statsManager.scoreController.ScoreUpdate();
        if (questions.Count <= 0)
        {
            endPanel.SetActive(true);
            endPanel.GetComponent<EndScreenController>().ShowScreen(
                $"Your score is {GlobalSettings.instance.statsManager.scoreController.score:0.#} from " +
                $"{GlobalSettings.instance.statsManager.scoreController.allScore:0.#}");
            return;
        }

        current = questions.LastOrDefault();
        InitQuestion(questions.LastOrDefault());
        questions.RemoveAt(questions.Count - 1);
    }
    public void InitQuestion(QA question)
    {
        questionController.OnObjectUpdate(question.question);
        answerController.OnObjectUpdate(question.answer);
    }

    public void QuestionUpdate(bool isCorrect)
    {
        if(isCorrect)GlobalSettings.instance.statsManager.ScoreUpdate(current.points);
        GlobalSettings.instance.statsManager.AllScoreUpdate(current.points);
    }
}