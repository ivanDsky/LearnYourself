using System;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static GlobalSettings instance;

    public Color correctColor;
    public Color incorrectColor;
    public Color selectedColor;

    public float nextQuestionDelay = 1f;
    
    public QAManager qaManager;
    public StatsManager statsManager;
    
    public GlobalSettings()
    {
        instance = this;
    }
}
