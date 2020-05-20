using System.Collections.Generic;
using System.IO;
using System.Linq;
using AnswerTypes;
using Extensions;
using Folders;
using GameModeTypes;
using UnityEngine;
using QASpace;
using QuestionTypes;
using Save;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class QAManager : SerializedMonoBehaviour
{
    public Sprite spriteImage;
    [OdinSerialize]
    private List<QA> questions = new List<QA>();
    private QA current;

    [SerializeField]private QuestionController questionController;
    [SerializeField]private AnswerController answerController;
    [SerializeField]private GameObject endPanel;

    public void Adding()
    {
        if (Folder.DefaultFolder.folders.Count + Folder.DefaultFolder.questions.Count > 0)
        {
            questions = Folder.DefaultFolder.GetSelectedQuestions();
            return;
        }
        questions.Add(
            new QA(
                new TextQuestion("Кто может быть лучше разработчика этой игры?","Про разраба"),
                new SimpleAnswer(new List<AnswerData> {new AnswerData("Никто", true)}),
                new GameModeDefault()
                ));
        questions.Add(
            new QA(
                new TextQuestion("Получит ли Ира 1000 подписчиков","Про Иру"),
                new SimpleAnswer(new List<AnswerData>
                {
                    new AnswerData("Конечно получит", true),
                    new AnswerData("Ха-ха, нет конечно", false),
                    new AnswerData("Если сильно постарается, то получит", true),
                }),
                new GameModeDefault(),
                "Ira"
                ));
        questions.Add(
            new QA(
                new ImageQuestion(spriteImage,"Про картинку"), 
                new InputAnswer(new AnswerData("Это картинка",true)), 
                new GameModeDefault(),
                "Match/Picture"
                ));
        questions.Add(
            new QA(
                new TextQuestion("Тут надо будет соеденить вопрос с ответом","Соеденения всякие"), 
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
                new GameModeDefault(),
                "Match"
            ));
    }
    
    public void Awake()
    {
        Adding();
        SaveSystem.SaveToFile(@"D:\text.save",questions);
        questions = SaveSystem.LoadFromFile<List<QA>>(@"D:\text.save");
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