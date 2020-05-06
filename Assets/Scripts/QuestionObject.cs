using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "New question", menuName = "Question/Create question", order = 51)]
    public class QuestionObject : SerializedScriptableObject
    {
        public new string name;
        public string questionText;
        public List<Question> answers;
    }
}