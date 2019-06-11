using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrefsX : MonoBehaviour {

    /// <summary>
    /// Stores a Int Array or Multiple Parameters into a Key
    /// </summary>
    public static void SetIntArray(string key, int[,] intArray)
    {
        for(int i = 0; i < 15; i++)
        {
            for(int j = 0; j < 15; j++)
            {
                PlayerPrefs.SetInt(key + i + "" + j, intArray[i, j]);
            }
        }
        return;
    }

    /// <summary>
    /// Returns a Int Array from a Key
    /// </summary>
    public static int[,] GetIntArray(string key)
    {
        int[,] intArray = new int[15, 15];
        if (PlayerPrefs.HasKey(key + 0 + "" + 0))
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    intArray[i, j] = PlayerPrefs.GetInt(key + i + "" + j);
                }
            }
            Debug.Log("Load Success");
        }
        else
        {
            Debug.Log("No found");
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    intArray[i, j] = 0;
                }
            }
        }
        return intArray;
    }
}
