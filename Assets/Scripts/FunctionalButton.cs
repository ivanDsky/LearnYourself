using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class FunctionalButton : MonoBehaviour
{
    protected Image image;
    protected Color saveColor;

    protected virtual void Awake()
    {
        image = GetComponent<Image>();
        saveColor = image.color;
    }

    public virtual void Reset()
    {
        ChangeColor(saveColor);
    }

    public virtual void CorrectAction()
    {
        ChangeColor(GlobalSettings.instance.correctColor);
    }
    
    public virtual void IncorrectAction()
    {
        ChangeColor(GlobalSettings.instance.incorrectColor);
    }

    public virtual void OnSelect()
    {
        ChangeColor(GlobalSettings.instance.selectedColor);
    }
    
    public void ChangeColor(Color newColor)
    {
        image.color = newColor;
    }
}
