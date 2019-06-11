using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ReferenceTable
{
    public static int turns = 0;
    public static int black_if_player=1;
    public static int white_if_player=1;
    public static int now_if_player=0;
    public static int if_start = 0;
    public static int if_first = 0;
    public static int if_loading = 0;
    public static int if_defence = 0;

    public static int[,] checkerboard = new int[15, 15];
    public static int[] now_position = new int[2];

    public static void Initialize()
    {
        int i,j;
        for (i = 0; i < 15; i++)
        {
            for (j = 0; j < 15; j++)
            {
                checkerboard[i, j] = 0;
            }
        }
        //now_position[0] = 7;
        //now_position[1] = 7;
    }

    public static void Addturns()
    {
        turns++;
        if (if_loading == 0)
        {
            GameObject.Find("CenterPoint").GetComponent<Change>().number = 0;
        }
           
    }
}