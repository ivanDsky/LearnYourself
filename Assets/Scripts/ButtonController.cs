using System;
using AnswerTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Color correctColor;
    public Color incorrectColor;
    private TextMeshProUGUI text;
    private Image image;
    private bool isCorrect;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        image = GetComponent<Image>();
    }

    public void InitContent(AnswerData data)
    {
        text.text = data.data;
        isCorrect = data.isCorrect;
    }

    public void CheckCorrectness()
    {
        image.color = isCorrect ? correctColor : incorrectColor;
    }
}