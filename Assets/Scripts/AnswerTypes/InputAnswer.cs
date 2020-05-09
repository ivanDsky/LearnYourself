namespace AnswerTypes
{
    public class InputAnswer : IAnswerType
    {
        public string Text { get; set; }
        public AnswerTypes AnswerType => AnswerTypes.Input;
    }
}