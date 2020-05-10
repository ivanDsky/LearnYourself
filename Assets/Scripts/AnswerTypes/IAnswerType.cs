using System.Collections.Generic;

namespace AnswerTypes
{
    public interface IAnswerType
    {
        List<AnswerData> Data { get; set;}
        AnswerTypes AnswerType { get;}
    }
}