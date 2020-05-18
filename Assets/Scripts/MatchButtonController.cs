using System;
using AnswerTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchButtonController : FunctionalButton
{
    public GameObject correctPairButton;
    public GameObject selectedPairButton;
    private TextMeshProUGUI text;

    
    public void Sync()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void InitContent(AnswerData data)
    {
        text.text = data.data;
    }

    public override void Reset()
    {
        base.Reset();
        selectedPairButton = null;
    }

    public void CheckCorrectness()
    {
        if (selectedPairButton == null) return;
        bool isCorrect = correctPairButton == selectedPairButton;
        if(isCorrect)
            CorrectAction();
        else
            IncorrectAction();
        GlobalSettings.instance.qaManager.QuestionUpdate(isCorrect);
    }
}