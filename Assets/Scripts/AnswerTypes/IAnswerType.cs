using System.Collections.Generic;

namespace AnswerTypes
{
    public interface IAnswerType : IType<AnswerType>
    {
        List<AnswerData> Data { get; set;}
    }
}