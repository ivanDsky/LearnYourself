using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ButtonActions : MonoBehaviour
    {
        public bool isCorrect;
        public Color correctColor, incorrectColor;
        private Image _image;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void ChangeColor()
        {
            _image.color = isCorrect ? correctColor : incorrectColor;
        }
    }
}