using UnityEngine;
using UnityEngine.UI;

namespace QuestionTypes
{
    public class ImageQuestion : IQuestionType
    {
        public QuestionType Type => QuestionType.Image;
        private Sprite Image { get; set; }
        
        public void InitContent(GameObject obj)
        {
            obj.GetComponent<Image>().sprite = Image;
            //TODO: save picture ratio on pasting
        }

        public ImageQuestion(Sprite image)
        {
            Image = image;
        }
    }
}