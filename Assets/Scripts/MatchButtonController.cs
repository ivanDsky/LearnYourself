using System;
using AnswerTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchButtonController : MonoBehaviour
{
    public GameObject correctPairButton;
    public GameObject selectedPairButton;
    public Image image;
    public Color saveColor;
    private TextMeshProUGUI text;

    
    public void Sync()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponent<Image>();
        saveColor = image.color;
    }

    public void InitContent(AnswerData data)
    {
        text.text = data.data;
    }

    public void Reset()
    {
        selectedPairButton = null;
        SetColor(saveColor);
    }

    public void CheckCorrectness()
    {
        if (selectedPairButton == null) return;
        bool isCorrect = correctPairButton == selectedPairButton;
        SetColor(isCorrect
            ? GlobalSettings.instance.correctColor
            : GlobalSettings.instance.incorrectColor);
        GlobalSettings.instance.qaManager.QuestionUpdate(isCorrect);
    }

    public void Select()
    {
        SetColor(GlobalSettings.instance.selectedColor);
    }

    public void SetColor(Color color)
    {
        image.color = color;
    }
}