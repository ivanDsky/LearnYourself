using System;
using QuestionTypes;
using Sirenix.OdinInspector;
using UnityEngine;
public class QuestionController : Controller<IQuestionType>
{
    public IQuestionType[] questions = {new TextQuestion(), new AudioQuestion(),new TextQuestion()};
    private int questionsID;
    
    //TODO temporary
    [Button]
    public void Next()
    {
        if (questionsID >= questions.Length) return;
        OnObjectUpdate(questions[questionsID++]);
    }
}
