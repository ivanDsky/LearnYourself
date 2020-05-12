using System;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public QAManager qaManager;

    private void Start()
    {
        qaManager.Next();
    }
}