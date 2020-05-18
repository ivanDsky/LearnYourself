using System;
using QASpace;
using UnityEngine;
using UnityEngine.UI;

namespace Folders
{
    public class QuestionButtonController : FunctionalButton
    {
        public QA question;
        public Folder parent;

        private void Start()
        {
            if (question.isSelected)
            {
                question.isSelected = !question.isSelected;
                OnSelectChange();
            }
        }

        public void OnSelectChange()
        {
            question.isSelected = !question.isSelected;
            if(question.isSelected)OnSelect();else Reset();
        }
    }
}