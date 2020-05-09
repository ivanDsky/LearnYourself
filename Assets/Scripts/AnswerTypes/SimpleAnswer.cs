namespace AnswerTypes
{
    public class SimpleAnswer : IAnswerType
    {
        public string Text { get; set; }
        public AnswerTypes AnswerType => AnswerTypes.Simple;
        public bool isCorrect = false;
    }
}