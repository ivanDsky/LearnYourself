using System;
using System.Collections.Generic;
using AnswerTypes;
using GameModeTypes;
using QuestionTypes;
using Save;
using Sirenix.Serialization;
using UnityEngine;

namespace QASpace
{
    public class QA
    {
        public IQuestionType question;
        public IAnswerType answer;
        public List<QATag> tags = new List<QATag>{QATag.Default};
        public IGameModeType gameMode;
        public string path;
        public float points;
        public bool isSelected;

        public QA(IQuestionType question, IAnswerType answer, IGameModeType gameMode,string path = "",float points = 1)
        {
            this.question = question;
            this.answer = answer;
            this.gameMode = gameMode;
            this.points = points;
            this.path = path;
            Folders.Folder.DefaultFolder.AddQuestion(this);
        }
    }
}
