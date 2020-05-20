using System;
using System.Diagnostics.CodeAnalysis;
using Sirenix.Serialization;

namespace AnswerTypes
{
    [Serializable]
    public class AnswerData
    {
        [OdinSerialize]
        private string data;
        public string Data
        {
            get => data;
            set => data = value;
        }

        [OdinSerialize]
        private bool isCorrect;
        public bool IsCorrect
        {
            get => isCorrect;
            set => isCorrect = value;
        }

        public AnswerData(string data,bool isCorrect = false)
        {
            Data = data;
            IsCorrect = isCorrect;
        }
    }
}