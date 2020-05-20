using System;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.UI;

namespace QuestionTypes
{
    [Serializable]
    public class ImageQuestion : IQuestionType
    {
        [OdinSerialize]
        private string name;

        public string Name
        {
            get => name;
            set => name = value;
        }
        public QuestionType Type => QuestionType.Image;
        private Sprite image;

        public Sprite Image
        {
            get => image;
            set => image = value;
        }
        

        public void InitContent(GameObject obj)
        {
            obj.GetComponent<Image>().sprite = Image;
            //TODO: save picture ratio on pasting
        }

        public ImageQuestion(Sprite image,string name)
        {
            Image = image;
            Name = name;
        }
    }
}