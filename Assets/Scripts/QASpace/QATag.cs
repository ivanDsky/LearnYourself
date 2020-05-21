using System;

namespace QASpace
{
    [Serializable]
    public class QATag
    {
        public QATag()
        {
        }

        public static readonly QATag Default = new QATag("Default");
        public string name { get; }

        public QATag(string name)
        {
            this.name = name;
        }
        

    }
}