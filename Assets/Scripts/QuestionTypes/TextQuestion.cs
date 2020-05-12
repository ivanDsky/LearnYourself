using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace QuestionTypes
{
    [Serializable]
    public class TextQuestion : IQuestionType
    {
        public QuestionType Type => QuestionType.Text;
        public void InitContent(GameObject content)
        {
            Debug.Log(content);
            content.GetComponent<TextMeshProUGUI>().text = Text;
        }

        public string Text { get; set; }

        public TextQuestion(string text)
        {
            Text = text;
        }
    }
}