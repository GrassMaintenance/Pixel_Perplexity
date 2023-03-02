using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools {
    
    public static T[] Shuffle<T>(T[] array, System.Random rg) {
        int n = array.Length;
        while (n > 1) {
            int k = rg.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
        return array;
    }

}

