using System;
using Extensions;
using UnityEngine;
using UnityEngine.UI;

public class MatchCheckButtonController : MonoBehaviour
{
   public MatchAnswerController answerController;

   public void Awake()
   {
      GetComponent<Button>().onClick.AddListener(() =>
      {
         GetComponent<Timer>().SetTimer(()=>
         {
            GlobalSettings.instance.qaManager.Next();
            answerController.gameObject.SetActive(false);
         }, GlobalSettings.instance.nextQuestionDelay);
         
      });
   }

   public void CheckCorrectness()
   {
      foreach (Transform button in answerController.firstPart.transform.GetChild(0))
      {
         button.GetComponent<MatchButtonController>().CheckCorrectness();
      }
      foreach (Transform button in answerController.secondPart.transform.GetChild(0))
      {
         button.GetComponent<MatchButtonController>().CheckCorrectness();
      }
      answerController.Block();
   }
}