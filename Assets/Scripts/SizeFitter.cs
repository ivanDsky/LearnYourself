using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(VerticalLayoutGroup)),RequireComponent(typeof(RectTransform))]
public class SizeFitter : MonoBehaviour
{
    private VerticalLayoutGroup verticalGroup;
    private RectTransform rectTransform;

    private void Awake()
    {
        verticalGroup = GetComponent<VerticalLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    [Button]
    public void Resize()
    {
        float height = 0;
        foreach (Transform x in transform)
        {
            height += x.GetComponent<RectTransform>().sizeDelta.y;
            
        }
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x,
            height + transform.childCount * verticalGroup.spacing + verticalGroup.padding.top + verticalGroup.padding.bottom);
    }
}