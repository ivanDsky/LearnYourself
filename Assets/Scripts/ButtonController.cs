using System;
using AnswerTypes;
using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private TextMeshProUGUI text;
    private bool isCorrect;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void InitContent(AnswerData data)
    {
        text.text = data.data;
        isCorrect = data.isCorrect;
    }
}