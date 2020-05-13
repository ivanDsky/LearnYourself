using UnityEngine;
using UnityEngine.UI;

public class BlockAllButtons : MonoBehaviour
{
    public void Block()
    {
        foreach (Transform button in transform)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }

    public void Unblock()
    {
        foreach (Transform button in transform)
        {
            button.GetComponent<Button>().interactable = true;
        }
    }
}