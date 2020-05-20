using System.Collections.Generic;
using Sirenix.Serialization;
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
        [OdinSerialize]
        private List<AnswerData> data;

        public List<AnswerData> Data
        {
            get => data;
            set => data = value;
        }

        public InputAnswer(AnswerData data)
        {
            data.IsCorrect = true;
            Data = new List<AnswerData>{data};
        }
    }
}