using System.Collections.Generic;

namespace AnswerTypes
{
    public class SimpleAnswer : IAnswerType
    {
        public List<AnswerData> Data { get; set; }
        public AnswerType Type => AnswerType.Simple;
    }
}