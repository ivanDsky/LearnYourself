using System;
using System.Collections.Generic;
using QASpace;
using TMPro;
using UnityEngine;

namespace Folders
{
    public class FolderController : MonoBehaviour
    {
        public Folder folder = Folder.DefaultFolder;
        public ButtonCreator folderCreator;
        public ButtonCreator questionCreator;
        public void Awake()
        {
            ButtonCreator[] x = GetComponentsInChildren<ButtonCreator>();
            folderCreator = x[0];
            questionCreator = x[1];
        }

        public void InitContent()
        {
            folderCreator.InitButtons(folder.folders.Count);
            questionCreator.InitButtons(folder.folders.Count + folder.questions.Count);
            for (int i = 0; i < folder.folders.Count; ++i)
            {
                if(folder.isSelected)folder.folders[i].isSelected = true;
                folderCreator.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text =
                    folder.folders[i].folderName;
                folderCreator.transform.GetChild(i).GetComponent<FolderButtonController>().folder = folder.folders[i];
            }
            for (int i = 0; i < folder.questions.Count; ++i)
            {
                if(folder.isSelected)folder.questions[i].isSelected = true;
                folderCreator.transform.GetChild(i + folder.folders.Count).GetComponent<QuestionButtonController>().question = folder.questions[i];
                questionCreator.transform.GetChild(i + folder.folders.Count).GetComponentInChildren<TextMeshProUGUI>()
                        .text = folder.questions[i].question.name;
            }
        }
    }
}