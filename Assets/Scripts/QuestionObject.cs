using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "Create question",fileName = "New question",order = 51)]
public class QuestionObject : SerializedScriptableObject
{
    public new string name;
    public string question;
    public bool haveVariants = true;
    [ShowIf("@this.haveVariants")]
    public List<string> answers;
    [ShowIf("@!this.haveVariants")]
    public string answerNoVariants;
}
