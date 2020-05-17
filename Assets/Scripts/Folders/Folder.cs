using System;
using System.Collections.Generic;
using System.Linq;
using QASpace;

namespace Folders
{
    public class Folder
    {
        public static readonly Folder DefaultFolder = new Folder("");
        public List<Folder> folders;
        public List<QA> questions;
        public readonly string folderName;
        public bool isSelected;
        public void AddQuestion(QA question)
        {
            Folder current = DefaultFolder;
            if (question.path != null)
            {
                List<string> path = SplitPath(question.path);
                foreach (var fName in path)
                {
                    Folder next = current.Get(fName);
                    if (next == null)
                    {
                        next = new Folder(fName);
                        current.folders.Add(next);
                    }
                    current = next;
                }
            }

            current.questions.Add(question);
        }

        private Folder(string folderName)
        {
            this.folderName = folderName;
            folders = new List<Folder>();
            questions = new List<QA>();
        }

        private Folder Get(string name)
        {
            foreach (var t in folders)
            {
                if (name == t.folderName) return t;
            }

            return null;
        }

        private List<string> SplitPath(string path)
        {
            if (path == null) return null;
            List<string> ret = new List<string>();
            string current = String.Empty;
            for (int i = 0; i < path.Length; ++i)
            {
                if (path[i] == '/')
                {
                    if(current != String.Empty)ret.Add(current);
                    current = String.Empty;
                }
                else
                {
                    current += path[i];
                }
            }
            if(current.Length > 0)ret.Add(current);
            return ret;
        }

        public List<QA> GetSelectedQuestions()
        {
            List<QA> ret = new List<QA>();
            if(isSelected)ret.AddRange(GetAllQuestions());
            else
                foreach (var folder in folders)
                {
                    ret.AddRange(folder.GetSelectedQuestions());
                }

            ret.AddRange(questions.Where(question => question.isSelected));
            
            return ret;
        }
        
        public List<QA> GetAllQuestions()
        {
            List<QA> ret = new List<QA>();
            foreach (var folder in folders)
            {
                ret.AddRange(folder.GetAllQuestions());
            }

            ret.AddRange(questions);
            
            return ret;
        }

        public void CheckSelection()
        {
            if (this == DefaultFolder) return;
            foreach (var folder in folders)
            {
                if (!folder.isSelected) isSelected = false;
            }

            foreach (var question in questions)
            {
                if (!question.isSelected) isSelected = false;
            }
        }

    }
}