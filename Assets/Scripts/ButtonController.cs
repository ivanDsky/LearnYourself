using System;
using AnswerTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Image image;
    private bool isCorrect;
    private Color saveColor;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponent<Image>();
        saveColor = image.color;
    }
    
    public void InitContent(AnswerData data)
    {
        text.text = data.data;
        isCorrect = data.isCorrect;
    }

    public void CheckCorrectness()
    {
        GlobalSettings.instance.qaManager.QuestionUpdate(isCorrect);
        if (isCorrect) 
            CorrectAction();
        else
            IncorrectAction();
    }

    public void CorrectAction()
    {
        image.color = GlobalSettings.instance.correctColor;
    }
    
    public void IncorrectAction()
    {
        image.color = GlobalSettings.instance.incorrectColor;
    }
    
    public void Reset()
    {
        image.color = saveColor;
    }
}