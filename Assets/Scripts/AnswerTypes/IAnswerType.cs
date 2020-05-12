using System.Collections.Generic;
using UnityEngine;

namespace AnswerTypes
{
    public interface IAnswerType
    {
        AnswerType Type { get; }
        void InitContent(GameObject obj);
        List<AnswerData> Data { get; set;}
    }
}