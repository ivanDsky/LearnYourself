using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class QuestionController : MonoBehaviour
    {
        public ButtonController buttonController;
        public List<QuestionObject> questions;
        public Transform answerGroup;
        public TextMeshProUGUI questionText;

        private void Start()
        {
            questions = Resources.LoadAll<QuestionObject>("/").ToList();//TODO customize folder to load
            InitQuestion(RandomFunctions.GetRandomObject(ref questions,true));
        }

        public void InitQuestion(QuestionObject question)
        {
            //TODO less get component
            questionText.text = question.questionText;
            buttonController.PrepareButtons(question.answers.Count);
            RandomFunctions.Shuffle(ref question.answers);
            for (int i = 0; i < question.answers.Count; ++i)
            {
                Transform button = answerGroup.GetChild(i);
                button.GetComponentInChildren<TextMeshProUGUI>().text = question.answers[i].text;
                button.GetComponentInChildren<Image>().color = Color.white;
                button.GetComponentInChildren<ButtonActions>().isCorrect = question.answers[i].isCorrect;
            }
        }
    }
}