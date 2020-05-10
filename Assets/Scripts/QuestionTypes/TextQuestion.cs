using System.Collections.Generic;
using UnityEngine;

namespace QuestionTypes
{
    public class TextQuestion : IQuestionType
    {
        public QuestionType Type => QuestionType.Text;
        public string Text { get; set; }
    }
}