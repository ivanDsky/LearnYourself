using Extensions;
using UnityEngine;

public class MatchAnswerController : MonoBehaviour
{
    public GameObject firstPart;
    public GameObject secondPart;
    public GameObject selected;

    public void OnButtonClick(GameObject obj)
    {
        if (obj.GetComponent<MatchButtonController>().selectedPairButton != null)
        {
            ResetSelected(obj.GetComponent<MatchButtonController>());
        }
        if (selected == null)
        {
            selected = obj;
            obj.GetComponent<MatchButtonController>().OnSelect();
        }
        else
        {
            if (obj.transform.parent == selected.transform.parent)
            {
                selected.GetComponent<MatchButtonController>().Reset();
                selected = obj;
                obj.GetComponent<MatchButtonController>().OnSelect();
            }
            else
            {
                //TODO: make normal selection
                selected.GetComponent<MatchButtonController>().selectedPairButton = obj;
                obj.GetComponent<MatchButtonController>().selectedPairButton = selected;
                Color rndColor = RandomExtensions.RandomColor();
                selected.GetComponent<MatchButtonController>().ChangeColor(rndColor);
                obj.GetComponent<MatchButtonController>().ChangeColor(rndColor);
                selected = null;
            }
        }
    }

    public void ResetSelected(MatchButtonController controller)
    {
        while (true)
        {
            if (controller.selectedPairButton == null) break;
            MatchButtonController next = controller.selectedPairButton.GetComponent<MatchButtonController>();
            controller.Reset();
            controller = next;
        }
    }

    public void Block()
    {
        firstPart.GetComponentInChildren<BlockAllButtons>().Block();
        secondPart.GetComponentInChildren<BlockAllButtons>().Block();
    }

    public void Unblock()
    {
        firstPart.GetComponentInChildren<BlockAllButtons>().Unblock();
        secondPart.GetComponentInChildren<BlockAllButtons>().Unblock();
    }
}
