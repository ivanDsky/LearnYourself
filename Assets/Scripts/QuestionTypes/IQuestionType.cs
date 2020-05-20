using System.Collections.Generic;
using Save;
using UnityEngine;

namespace QuestionTypes
{
    public interface IQuestionType
    {
        string Name { get; set; }
        QuestionType Type { get; }
        void InitContent(GameObject obj);
    }
}