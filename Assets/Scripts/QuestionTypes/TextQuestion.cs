using System.Collections.Generic;
using UnityEngine;

namespace QuestionTypes
{
    public class TextQuestion : IQuestionType
    {
        public List<string> Tags { get; set; }
        public string Path { get; set; }
        public QuestionType QuestionType => QuestionType.Text;
        public string Text { get; set; }
    }
}