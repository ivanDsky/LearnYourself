using UnityEditor;
using UnityEngine;

public class EndButtonController : MonoBehaviour
{
    public void ExitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}