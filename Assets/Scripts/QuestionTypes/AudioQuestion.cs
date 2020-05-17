using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuestionTypes
{
    [Serializable]
    public class AudioQuestion : IQuestionType
    {
        public string name { get; set; }
        public QuestionType Type => QuestionType.Audio;
        public void InitContent(GameObject obj)
        {
            throw new NotImplementedException();//TODO implement audio init
        }

        public AudioClip Track { get; set; }
    }
}