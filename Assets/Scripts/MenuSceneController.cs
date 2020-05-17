using System;
using UnityEngine;
public class MenuSceneController : MonoBehaviour
{
    public static MenuSceneController controller;

    public Transform folderParent;

    public void Awake()
    {
        if (controller == null) controller = this;
    }
}