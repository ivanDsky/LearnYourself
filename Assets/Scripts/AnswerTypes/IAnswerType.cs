using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace AnswerTypes
{
    public interface IAnswerType
    {
        AnswerType Type { get; }
        void InitContent(GameObject obj);
        [OdinSerialize]
        List<AnswerData> Data { get; set;}
    }
}