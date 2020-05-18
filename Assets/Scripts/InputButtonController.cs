using System;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputButtonController : FunctionalButton
{
    public GameObject input;
    private InputController controller;
    private TMP_InputField field;

    protected override void Awake()
    {
        controller = input.GetComponent<InputController>();
        field = input.GetComponentInChildren<TMP_InputField>();
        image = field.gameObject.GetComponent<Image>();
        saveColor = image.color;

        Timer timer = GetComponent<Timer>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            timer.SetTimer(GlobalSettings.instance.qaManager.Next,GlobalSettings.instance.nextQuestionDelay);
        }
        );
    }

    public void CheckCorrectness()
    {
        var isCorrect = controller.correctText == field.text;
        GlobalSettings.instance.qaManager.QuestionUpdate(isCorrect);
        if(isCorrect)
            CorrectAction();
        else
            IncorrectAction();
        GetComponent<Button>().interactable = false;
    }
    
    public override void Reset()
    {
        base.Reset();
        GetComponent<Button>().interactable = true;
    }
}