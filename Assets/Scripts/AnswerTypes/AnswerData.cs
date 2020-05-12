using System;
namespace AnswerTypes
{
    [Serializable]
    public class AnswerData
    {
        public string data;
        public bool isCorrect = false;

        public AnswerData(string data,bool isCorrect)
        {
            this.data = data;
            this.isCorrect = isCorrect;
        }
    }
}