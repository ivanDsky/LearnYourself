using System;
using Save;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;

namespace QuestionTypes
{
    [Serializable]
    public class TextQuestion : IQuestionType
    {
        [OdinSerialize]
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public QuestionType Type => QuestionType.Text;
        public void InitContent(GameObject content)
        {
            content.GetComponent<TextMeshProUGUI>().text = Text;
        }
        [OdinSerialize]
        private string text;

        public string Text
        {
            get => text; 
            set => text = value;
        }

        public TextQuestion(string text,string name)
        {
            Name = name;
            Text = text;
        }
    }
}