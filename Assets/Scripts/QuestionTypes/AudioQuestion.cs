using System.Collections.Generic;
using UnityEngine;

namespace QuestionTypes
{
    public class AudioQuestion : IQuestionType
    {
        public QuestionType Type => QuestionType.Audio;
        public AudioClip Track { get; set; }
    }
}