using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public static class RandomFunctions
    {
        public static void Shuffle<T>(ref List<T> list)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                int randomPos = Random.Range(0, i);
                T save = list[randomPos];
                list[randomPos] = list[i];
                list[i] = save;
            }
        }
        
        public static T GetRandomObject<T>(ref List<T> list,bool remove = false){
            int listPos = Random.Range(0, list.Count);
            T ret = list[listPos];
            if (remove) list.RemoveAt(listPos);
            return ret;
        }

    }
    
}