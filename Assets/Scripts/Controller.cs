using System;
using UnityEngine;

public abstract class Controller<T> : MonoBehaviour
{
    private event Action<T> ObjectUpdate;
    public void AddListener(Action<T> action)
    {
        ObjectUpdate += action;
    }
    
    public void RemoveListener(Action<T> action)
    {
        ObjectUpdate -= action;
    }

    public void OnObjectUpdate(T obj)
    {
        ObjectUpdate?.Invoke(obj);
    }
}
