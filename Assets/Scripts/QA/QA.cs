using System.Collections.Generic;
using AnswerTypes;
using QuestionTypes;

namespace QA
{
    public class QA
    {
        public IQuestionType question;
        public IAnswerType answer;
        public readonly List<QATag> tags = new List<QATag>();//TODO not readonly
        public QAType type = QAType.Default;
        public string path;//TODO optional

        public QA()
        {
            tags.Add(QATag.Default);
        }
    }
}
