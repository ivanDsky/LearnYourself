using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class QuestionObject : SerializedScriptableObject
{
    public new string name;
    public string question;
    public List<string> answers;
}
