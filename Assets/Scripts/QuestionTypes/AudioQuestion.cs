using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace QuestionTypes
{
    [Serializable]
    public class AudioQuestion : IQuestionType
    {
        [OdinSerialize]
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public QuestionType Type => QuestionType.Audio;
        public void InitContent(GameObject obj)
        {
            throw new NotImplementedException();//TODO implement audio init
        }

        public AudioClip Track { get; set; }
    }
}