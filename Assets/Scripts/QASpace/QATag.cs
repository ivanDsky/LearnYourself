namespace QASpace
{
    public class QATag
    {
        public static readonly QATag Default = new QATag("Default");
        public string name { get; }

        public QATag(string name)
        {
            this.name = name;
        }

    }
}