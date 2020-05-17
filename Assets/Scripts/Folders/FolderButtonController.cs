using System;
using UnityEngine;
using UnityEngine.UI;

namespace Folders
{
    public class FolderButtonController : MonoBehaviour
    {
        public GameObject folderPrefab;
        public Folder folder = Folder.DefaultFolder;
        public Image image;
        public Color saveColor;

        private void Start()
        {
            image = GetComponent<Image>();
            saveColor = image.color;
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
            image.color = folder.isSelected ? GlobalSettings.instance.selectedColor : saveColor;
        }
    }
}