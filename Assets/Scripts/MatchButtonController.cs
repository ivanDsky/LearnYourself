using System;
using AnswerTypes;
using TMPro;
using UnityEngine;
public class MatchButtonController : MonoBehaviour
{
    public GameObject pairButton;
    private TextMeshProUGUI text;

    
    public void Sync()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void InitContent(AnswerData data)
    {
        text.text = data.data;
    }
}