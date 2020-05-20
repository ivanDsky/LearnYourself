using AnswerTypes;
using TMPro;

public class ButtonController : FunctionalButton
{
    private TextMeshProUGUI text;
    private bool isCorrect;

    protected override void Awake()
    {
        base.Awake();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void InitContent(AnswerData data)
    {
        text.text = data.Data;
        isCorrect = data.IsCorrect;
    }

    public void CheckCorrectness()
    {
        transform.parent.GetComponent<BlockAllButtons>().Block();
        GlobalSettings.instance.qaManager.QuestionUpdate(isCorrect);
        if (isCorrect) 
            CorrectAction();
        else
            IncorrectAction();
        
    }
}