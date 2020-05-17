using System;
using QASpace;
using UnityEngine;
using UnityEngine.UI;

namespace Folders
{
    public class QuestionButtonController : MonoBehaviour
    {
        public QA question;
        public Folder parent;
        public Image image;
        public Color saveColor;

        private void Start()
        {
            image = GetComponent<Image>();
            saveColor = image.color;
            if (question.isSelected)
            {
                question.isSelected = !question.isSelected;
                OnSelectChange();
            }
        }

        public void OnSelectChange()
        {
            question.isSelected = !question.isSelected;
            image.color = question.isSelected ? GlobalSettings.instance.selectedColor : saveColor;
        }
    }
}