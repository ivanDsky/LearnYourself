using System.IO;
using System.Text;
using Sirenix.Serialization;
using UnityEngine;

namespace Save
{
    public static class SaveSystem
    {
        private const DataFormat Format = DataFormat.Binary;

        public static void Save<T>(string key,T obj)
        {
            var bytes = SerializationUtility.SerializeValue(obj, Format);
            string set = Encoding.UTF8.GetString(bytes);
            PlayerPrefs.SetString(key,set);
        }
        
        public static void SaveToFile<T>(string path,T obj)
        {
            var bytes = SerializationUtility.SerializeValue(obj, Format);
            File.WriteAllBytes(path,bytes);
        }

        public static T Load<T>(string key)
        {
            string get = PlayerPrefs.GetString(key);
            var bytes = Encoding.ASCII.GetBytes(get);
            return SerializationUtility.DeserializeValue<T>(bytes, Format);
        }
        
        public static T LoadFromFile<T>(string path)
        {
            var bytes = File.ReadAllBytes(path);
            return SerializationUtility.DeserializeValue<T>(bytes, Format);
        }

    }
}