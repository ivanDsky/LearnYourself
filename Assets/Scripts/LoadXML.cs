using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Folders;
using QASpace;
using Sirenix.OdinInspector;
using UnityEngine;

public class LoadXML : MonoBehaviour
{
    [InlineButton("Awake","Load XML")] 
    public string path = @"D:\QA.xml";
    public void Awake()
    {
        Folder.DefaultFolder.folders.Clear();
        Folder.DefaultFolder.questions.Clear();
        XmlSerializer xml = new XmlSerializer(typeof(List<QA>));
        using (FileStream f = new FileStream(@path,FileMode.Open))
        {
            List<QA> questions = (List<QA>)xml.Deserialize(f);
            foreach (var q in questions)
            {
                Folder.DefaultFolder.AddQuestion(q);
            }
        }
        Debug.Log("Questions loaded");
    }
}