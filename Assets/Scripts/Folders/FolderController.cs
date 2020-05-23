using Doozy.Engine.UI;
using TMPro;
using UnityEngine;

namespace Folders
{
    public class FolderController : MonoBehaviour
    {
        public Folder folder = Folder.DefaultFolder;
        public ButtonCreator folderCreator;
        public ButtonCreator questionCreator;

        public void InitContent()
        {
            folderCreator.InitButtons(folder.folders.Count);
            questionCreator.InitButtons(folder.questions.Count);
            for (int i = 0; i < folder.folders.Count; ++i)
            {
                transform.GetChild(0).GetChild(0).GetChild(i).GetComponent<FolderButtonController>().folder = folder.folders[i];
                transform.GetChild(0).GetChild(0).GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = folder.folders[i].folderName;
            }
            for (int i = 0; i < folder.questions.Count; ++i)
            {
                transform.GetChild(0).GetChild(1).GetChild(i).GetComponent<QuestionButtonController>().parent = folder;
                transform.GetChild(0).GetChild(1).GetChild(i).GetComponent<QuestionButtonController>().question = folder.questions[i];
                transform.GetChild(0).GetChild(1).GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = folder.questions[i].question.Name;
            }
            transform.GetChild(0).GetComponent<SizeFitter>().Resize();
        }
    }
}