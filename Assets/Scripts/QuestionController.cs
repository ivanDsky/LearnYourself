using System;
using System.Collections;
using System.Collections.Generic;
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
        public float delayBetweenQuestions = .5f;

        private void Start()
        {
            InitQuestion(GetRandomQuestion(true));
        }

        public void InitQuestion(QuestionObject question)
        {
            questionText.text = question.questionText;
            buttonController.PrepareButtons(question.answers.Count);
            for (int i = 0; i < question.answers.Count; ++i)
            {
                Transform button = answerGroup.GetChild(i);
                button.GetComponentInChildren<TextMeshProUGUI>().text = question.answers[i].text;
                button.GetComponentInChildren<Image>().color = Color.white;
                var i1 = i;
                button.GetComponentInChildren<Button>().onClick.AddListener(delegate
                {
                    EndAnswer(button.GetComponentInChildren<Image>(),question.answers[i1].isCorrect);
                });
            }
        }

        public QuestionObject GetRandomQuestion(bool remove = false)
        {
            int id = Random.Range(0, questions.Count);
            QuestionObject ret = questions[id];
            if (remove) questions.RemoveAt(id);
            return ret;
        }

        public void EndAnswer(Image image, bool isCorrect)
        {
            image.color = isCorrect ? Color.green : Color.red;
            StartCoroutine(EndAnswerCoroutine());
        }

        public IEnumerator EndAnswerCoroutine()
        {
            yield return new WaitForSeconds(delayBetweenQuestions);
            if (questions.Count > 0) InitQuestion(GetRandomQuestion(true));
        }
    }
}