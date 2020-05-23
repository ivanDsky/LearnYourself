using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Extensions;
using Folders;
using UnityEngine;
using QASpace;
using Sirenix.OdinInspector;

public class QAManager : SerializedMonoBehaviour
{
    private List<QA> questions = new List<QA>();
    private QA current;

    [SerializeField]private QuestionController questionController;
    [SerializeField]private AnswerController answerController;
    [SerializeField]private GameObject endPanel;

    public void Awake()
    {
        questions = Folder.DefaultFolder.GetAllQuestions();
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