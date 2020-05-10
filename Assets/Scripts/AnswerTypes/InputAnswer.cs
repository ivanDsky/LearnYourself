using System.Collections.Generic;

namespace AnswerTypes
{
    public class InputAnswer : IAnswerType
    {
        public AnswerTypes AnswerType => AnswerTypes.Input;
        public List<AnswerData> Data { get; set; }
    }
}