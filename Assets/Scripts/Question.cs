namespace DefaultNamespace
{
    public class Question
    {
        public string text;
        public bool isCorrect = false;

        public Question(string text,bool isCorrect)
        {
            this.text = text;
            this.isCorrect = isCorrect;
        }
    }
}