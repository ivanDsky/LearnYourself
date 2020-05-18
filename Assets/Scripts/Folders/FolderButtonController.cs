using System;
using UnityEngine;
using UnityEngine.UI;

namespace Folders
{
    public class FolderButtonController : FunctionalButton
    {
        public GameObject folderPrefab;
        public Folder folder = Folder.DefaultFolder;

        private void Start()
        {
            if (folder.isSelected)
            {
                folder.isSelected = !folder.isSelected;
                OnSelectChange();
            }
        }

        public void OnButtonClick()
        {
            GameObject folderObj = Instantiate(folderPrefab, MenuSceneController.controller.folderParent);
            folderObj.GetComponent<FolderController>().folder = folder;
            folderObj.GetComponent<FolderController>().InitContent();
        }
        

        public void OnSelectChange()
        {
            folder.isSelected = !folder.isSelected;
            if(folder.isSelected)OnSelect();
            else Reset();
        }
    }
}