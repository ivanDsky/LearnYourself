using System;
using TMPro;
using UnityEngine;

namespace QuestionTypes
{
    [Serializable]
    public class TextQuestion : IQuestionType
    {
        public string name { get; set; }
        public QuestionType Type => QuestionType.Text;
        public void InitContent(GameObject content)
        {
            content.GetComponent<TextMeshProUGUI>().text = Text;
        }

        public string Text { get; set; }

        public TextQuestion(string text,string name)
        {
            this.name = name;
            Text = text;
        }
    }
}