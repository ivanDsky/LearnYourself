using System;
using Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputButtonController : MonoBehaviour
{
    public GameObject input;
    private InputController controller;
    private TMP_InputField field;
    private Image image;
    private Color saveColor;

    private void Awake()
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
        image.color = isCorrect ? GlobalSettings.instance.correctColor : GlobalSettings.instance.incorrectColor;
    }
    
    public void Reset()
    {
        image.color = saveColor;
    }
}