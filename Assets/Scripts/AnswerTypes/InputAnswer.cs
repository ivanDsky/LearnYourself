using System.Collections.Generic;
using UnityEngine;

namespace AnswerTypes
{
    public class InputAnswer : IAnswerType
    {
        public AnswerType Type => AnswerType.Input;
        public void InitContent(GameObject obj)
        {
            obj.GetComponent<InputController>().InitContent(Data[0]);
        }

        public List<AnswerData> Data { get; set; }

        public InputAnswer(AnswerData data)
        {
            data.isCorrect = true;
            Data = new List<AnswerData>{data};
        }
    }
}