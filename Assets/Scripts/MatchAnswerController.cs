using Extensions;
using UnityEngine;

public class MatchAnswerController : MonoBehaviour
{
    public GameObject firstPart;
    public GameObject secondPart;

    public GameObject selected;
    
    public void OnButtonClick(GameObject obj)
    {
        if (selected == null)
        {
            selected = obj;
            obj.GetComponent<MatchButtonController>().Select();
        }
        else
        {
            if (obj.transform.parent == selected.transform.parent)
            {
                selected.GetComponent<MatchButtonController>().Reset();
                selected = obj;
                obj.GetComponent<MatchButtonController>().Select();
            }
            else
            {
                //TODO: make normal selection
                selected.GetComponent<MatchButtonController>().selectedPairButton = obj;
                obj.GetComponent<MatchButtonController>().selectedPairButton = selected;
                Color rndColor = RandomExtensions.RandomColor();
                selected.GetComponent<MatchButtonController>().SetColor(rndColor);
                obj.GetComponent<MatchButtonController>().SetColor(rndColor);
                selected = null;
            }
        }
    }
}
