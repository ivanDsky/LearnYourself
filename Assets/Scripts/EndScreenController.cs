using TMPro;
using UnityEngine;

public class EndScreenController : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void ShowScreen(string message)
    {
        gameObject.SetActive(true);
        text.text = message;
    }
}
