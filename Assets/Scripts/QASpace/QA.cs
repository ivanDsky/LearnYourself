using System;
using System.Collections.Generic;
using AnswerTypes;
using GameModeTypes;
using QuestionTypes;

namespace QASpace
{
    [Serializable]
    public class QA
    {
        public IQuestionType question;
        public IAnswerType answer;
        public List<QATag> tags = new List<QATag>{QATag.Default};
        public IGameModeType gameMode = new GameModeDefault();
        public string path;//TODO optional
        

        public QA(IQuestionType question, IAnswerType answer, IGameModeType gameMode)
        {
            this.question = question;
            this.answer = answer;
            this.gameMode = gameMode;
        }
    }
}
