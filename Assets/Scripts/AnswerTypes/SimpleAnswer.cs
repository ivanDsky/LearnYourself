using System;
using System.Collections.Generic;
using System.Linq;
using Extensions;
using TMPro;
using UnityEngine;

namespace AnswerTypes
{
    [Serializable]
    public class SimpleAnswer : IAnswerType
    {
        public void InitContent(GameObject content)
        {
            content.GetComponent<ButtonCreator>().InitButtons(Data.Count);
            content.GetComponent<ButtonCreator>().InitSimpleButton(Data.Count);
            for (int id = 0; id < Data.Count; id++)
            {
                content.transform.GetChild(id).GetComponent<ButtonController>().InitContent(Data[id]);
            }
        }

        public List<AnswerData> Data { get; set; }
        public AnswerType Type => AnswerType.Simple;

        public SimpleAnswer(List<AnswerData> data)
        {
            Data = data;
            if (!data.Any(t => t.isCorrect))
            {
                throw new Exception("List should consist correct answer");
            }
        }
    }
}