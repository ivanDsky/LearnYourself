using System.Collections.Generic;
using UnityEngine;

namespace QuestionTypes
{
    public interface IQuestionType
    {
        QuestionType Type { get; }
        void InitContent(GameObject obj);
    }
}