using System;
using System.Collections.Generic;
using AnswerTypes;
using QuestionTypes;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static GlobalSettings instance;

    public static readonly Dictionary<QuestionType, Type> questionDict = new Dictionary<QuestionType, Type>();
    public static readonly Dictionary<AnswerType, Type> answerDict = new Dictionary<AnswerType, Type>();

    public Color correctColor;
    public Color incorrectColor;
    public Color selectedColor;

    public float nextQuestionDelay = 1f;
    
    public QAManager qaManager;
    public StatsManager statsManager;

    public void AddDict()
    {
        questionDict.Add(QuestionType.Text,typeof(TextQuestion));
        questionDict.Add(QuestionType.Image,typeof(ImageQuestion));
        questionDict.Add(QuestionType.Audio,typeof(AudioQuestion));
        answerDict.Add(AnswerType.Simple,typeof(SimpleAnswer));
        answerDict.Add(AnswerType.Input,typeof(InputAnswer));
        answerDict.Add(AnswerType.Match,typeof(MatchAnswer));
    }
    
    public GlobalSettings()
    {
        if(questionDict.Count == 0)AddDict();
        instance = this;
    }
}
