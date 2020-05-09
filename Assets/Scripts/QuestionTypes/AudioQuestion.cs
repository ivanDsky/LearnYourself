using System.Collections.Generic;
using UnityEngine;

namespace QuestionTypes
{
    public class AudioQuestion : IQuestionType
    {
        public List<string> Tags { get; set; }
        public string Path { get; set; }
        public QuestionType QuestionType => QuestionType.Audio;
        public AudioClip Track { get; set; }
    }
}