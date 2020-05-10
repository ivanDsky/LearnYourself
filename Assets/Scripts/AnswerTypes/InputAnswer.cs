using System;
using System.Collections.Generic;

namespace AnswerTypes
{
    public class InputAnswer : IAnswerType
    {
        private List<AnswerData> data;
        public AnswerType Type => AnswerType.Input;

        public List<AnswerData> Data
        {
            get => data;
            set
            {
                if (value.Count >= 2)
                {
                    throw new Exception("Input answer data can be only single");
                }
                data = value;
            }
        }
    }
}