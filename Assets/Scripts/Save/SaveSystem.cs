using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Save
{
    public static class SaveSystem
    {
        public static void Save<T>(T obj, string path = "")
        {
            if (path == "")
            {
                PlayerPrefs.SetString(obj.GetHashCode().ToString(),JsonUtility.ToJson(obj));
            }
            else
            {
                File.WriteAllText(JsonUtility.ToJson(obj),path + "/save.json");
            }
        }

        public static T Load<T>(string path)
        {
            T ret = JsonUtility.FromJson<T>(File.ReadAllText(path));
            return ret;
        }
        
    }
}