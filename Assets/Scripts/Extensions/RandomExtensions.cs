using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Shuffle list of elements
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static void Shuffle<T>(this IList<T> list) 
        {
            if (list == null)
            {
                Debug.Log("List is Empty");
                return;
            }
            for (int i = 1; i < list.Count; i++)
            {
                int randomID = Random.Range(0, i + 1);
                T z = list[i];
                list[i] = list[randomID];
                list[randomID] = z;
            }
        }

        public static Color RandomColor()
        {
            Color ret;
            ret.r = Random.Range(0f, 1f);
            ret.g = Random.Range(0f, 1f);
            ret.b = Random.Range(0f, 1f);
            ret.a = 1;
            return ret;
        }
    }
}