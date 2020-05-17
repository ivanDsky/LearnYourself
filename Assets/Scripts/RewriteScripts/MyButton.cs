using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RewriteScripts
{
    public class MyButton : Button
    {
        public UnityEvent onLongClick;

        public float longClickDuration =.2f ;

        private float startTime, endTime;
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            startTime = Time.time;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            endTime = Time.time;

            if (endTime - startTime >= longClickDuration)
            {
                onLongClick?.Invoke();
            }
            else
            {
                base.OnPointerClick(eventData);
            }
        }
    }

    
    
    
    
    [CustomEditor(typeof(MyButton), true)]
    [CanEditMultipleObjects]
    public class MyButtonEditor : ButtonEditor
    {
        SerializedProperty onLongClickProperty;
        SerializedProperty longClickDurationProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            onLongClickProperty = serializedObject.FindProperty("onLongClick");
            longClickDurationProperty = serializedObject.FindProperty("longClickDuration");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.Space();
            
            serializedObject.Update();
            EditorGUILayout.PropertyField(onLongClickProperty);
            EditorGUILayout.PropertyField(longClickDurationProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}