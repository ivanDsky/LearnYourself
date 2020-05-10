using System.Collections.Generic;

namespace AnswerTypes
{
    public class SimpleAnswer : IAnswerType
    {
        public AnswerTypes AnswerType => AnswerTypes.Simple;
        public List<AnswerData> Data { get; set; }
    }
}