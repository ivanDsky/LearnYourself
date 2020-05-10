using System.Collections.Generic;
using UnityEngine;

namespace QuestionTypes
{
    public class AudioQuestion : IQuestionType
    {
        public QuestionType QuestionType => QuestionType.Audio;
        public AudioClip Track { get; set; }
    }
}