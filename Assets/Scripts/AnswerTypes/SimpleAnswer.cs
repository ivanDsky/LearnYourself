using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using Sirenix.Serialization;
using TMPro;
using UnityEngine;

namespace AnswerTypes
{
    public class SimpleAnswer : IAnswerType
    {
        public AnswerType Type => AnswerType.Simple;
        public void InitContent(GameObject content)
        {
            content.GetComponent<ButtonCreator>().InitButtons(Data.Count);
            content.GetComponent<ButtonCreator>().InitSimpleButton(Data.Count);
            for (int id = 0; id < Data.Count; id++)
            {
                content.transform.GetChild(id).GetComponent<ButtonController>().InitContent(Data[id]);
            }
        }

        [OdinSerialize]
        private List<AnswerData> data;

        public List<AnswerData> Data
        {
            get => data;
            set => data = value;
        }

        public SimpleAnswer(List<AnswerData> data)
        {
            Data = data;
            if (!data.Any(t => t.IsCorrect))
            {
                throw new Exception("List should consist correct answer");
            }
        }

        public SimpleAnswer()
        {
        }
    }
}