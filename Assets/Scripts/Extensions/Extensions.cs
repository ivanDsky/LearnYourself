using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Reporting;

namespace Extensions
{
    public static class Extensions
    {

        /// <summary>
        /// Swap two elements
        /// </summary>
        /// <param name="x">First parameter</param>
        /// <param name="y">Second parameter</param>
        /// <typeparam name="T"></typeparam>
        public static void Swap<T>(ref T x,ref T y)
        {
            T z = y;
            y = x;
            x = z;
        }
        
        public static string ToStrings<T>(this T obj) where T : IEnumerable
        {
            string ret = "{";
            foreach (var elem in obj)
            {
                if (elem is IEnumerable) ret += ((IEnumerable) elem).ToStrings();
                else ret += elem.ToString();
                ret += ", ";
            }

            ret = ret.Remove(ret.Length - 2, 2);
            ret += "}";
            return ret;
        }
    }
    
}