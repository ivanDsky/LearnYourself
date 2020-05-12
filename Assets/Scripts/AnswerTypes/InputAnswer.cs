using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnswerTypes
{
    [Serializable]
    public class InputAnswer : IAnswerType
    {
        private List<AnswerData> data;
        public AnswerType Type => AnswerType.Input;

        public void InitContent(GameObject obj)
        {
            throw new NotImplementedException();
        }

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