using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Extensions
{
    public class ButtonFunctions : MonoBehaviour
    {
        public void ExitGame()
        {
            #if UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void LoadScene(int x)
        {
            SceneManager.LoadScene(x);
        }

        public void DestroyOnClick(GameObject target)
        {
            Destroy(target);
        }
        
        public void ColorChange(int id)
        {
            GetComponent<Image>().color = id == 0 ? Color.green : Color.red;
        }
    }
}