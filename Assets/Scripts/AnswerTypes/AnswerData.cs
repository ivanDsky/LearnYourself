using System;
namespace AnswerTypes
{
    [Serializable]
    public class AnswerData
    {
        public string data;
        public bool isCorrect;

        public AnswerData(string data,bool isCorrect = false)
        {
            this.data = data;
            this.isCorrect = isCorrect;
        }
    }
}