using System;
using System.Collections.Generic;
using UnityEngine;

namespace AnswerTypes
{
    public class MatchAnswer : IAnswerType
    {
        public AnswerType Type => AnswerType.Match;
        public void InitContent(GameObject obj)
        {
            Transform firstPart = obj.transform.GetChild(0).GetChild(0);
            Transform secondPart = obj.transform.GetChild(1).GetChild(0);
            firstPart.GetComponent<ButtonCreator>().InitButtons(data[0].Count);
            firstPart.GetComponent<ButtonCreator>().InitMatchButton(data[0].Count);
            secondPart.GetComponent<ButtonCreator>().InitButtons(data[1].Count);
            secondPart.GetComponent<ButtonCreator>().InitMatchButton(data[1].Count);
            for (int i = 0; i < data[0].Count; ++i)
            {
                Transform f = firstPart.GetChild(i);
                f.GetComponent<MatchButtonController>().pairButton = null;
                f.GetComponent<MatchButtonController>().InitContent(data[0][i]);
            }
            
            for (int i = 0; i < data[1].Count; ++i)
            {
                Transform s = secondPart.GetChild(i);
                s.GetComponent<MatchButtonController>().pairButton = null;
                s.GetComponent<MatchButtonController>().InitContent(data[1][i]);
            }
            
            for (int i = 0; i < Math.Min(data[0].Count, data[1].Count); ++i)
            {
                Transform f = firstPart.GetChild(i);
                Transform s = secondPart.GetChild(i);
                f.GetComponent<MatchButtonController>().pairButton = s.gameObject;
                s.GetComponent<MatchButtonController>().pairButton = f.gameObject;
            }
            //TODO: reorganize code and delete duplication
        }
        
        public List<AnswerData> Data { get; set; }
        private List<AnswerData>[] data;


        public MatchAnswer(List<AnswerData> firstPart,List<AnswerData> secondPart)
        {
            data = new[] {firstPart, secondPart};
        }
    }
}