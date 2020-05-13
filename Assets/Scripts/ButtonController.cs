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
        image.color = isCorrect ? GlobalSettings.instance.correctColor : GlobalSettings.instance.incorrectColor;
    }

    public void Reset()
    {
        image.color = saveColor;
    }
}