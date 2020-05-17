using System.Collections.Generic;
using UnityEngine;

namespace QuestionTypes
{
    public interface IQuestionType
    {
        string name { get; set; }
        QuestionType Type { get; }
        void InitContent(GameObject obj);
    }
}