using System.Collections.Generic;
using AnswerTypes;
using GameModeTypes;
using QuestionTypes;

namespace QA
{
    public class QA
    {
        public IQuestionType question;
        public IAnswerType answer;
        public readonly List<QATag> tags = new List<QATag>();//TODO not readonly
        public IGameModeType type = new GameModeDefault();
        public string path;//TODO optional

        public QA()
        {
            tags.Add(QATag.Default);
        }
    }
}
