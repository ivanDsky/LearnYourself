using System;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
   public float score;
   public float allScore;
   private TextMeshProUGUI text;

   private void Awake()
   {
      text = GetComponentInChildren<TextMeshProUGUI>();
   }

   public void ScoreAdd(float add)
   {
      score += add;
      ScoreUpdate();
   }
   
   public void AllScoreAdd(float add)
   {
      allScore += add;
      ScoreUpdate();
   }

   public void ScoreUpdate()
   {
      text.text = $"{score:0.#}/{allScore:0.#}";
   }
}