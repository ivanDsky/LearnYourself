using System;
using AnswerTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
    public string correctText;
    public InputButtonController buttonController;
    
    public void InitContent(AnswerData data)
    {
        buttonController.Reset();
        correctText = data.data;
    }
}