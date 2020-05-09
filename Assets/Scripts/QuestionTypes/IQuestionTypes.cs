using System.Collections.Generic;

namespace QuestionTypes
{
    public interface IQuestionType
    {
        List<string> Tags { get; set; }
        string Path { get; set; }
        QuestionType QuestionType { get; }
    }
}