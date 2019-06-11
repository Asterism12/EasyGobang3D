using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SituationCheck  {

    //start from left
    public static int[] Samenumber=new int[4];
    public static int[] If_sleep = new int[4];
    public static int Line(int player,int x,int y)
    {
        int i, nownumber=0;

        //ini
        for (i = 0; i < 4; i++)
        {
            Samenumber[i] = 0;
            If_sleep[i] = 1;
        }
        //check in a row
        for (i = 1; i < 5; i++)
        {
            //right
            if (i + x > 14)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else if (ReferenceTable.checkerboard[x + i, y] == player)
            {
                Samenumber[nownumber]++;
            }
            else if(ReferenceTable.checkerboard[x + i, y] != 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else
            {
                //If_sleep[nownumber] = 1;
                break;
            }
        }

        for (i = 1; i < 5; i++)
        {
            //left
            if (x - i < 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else if (ReferenceTable.checkerboard[x - i, y] == player)
            {
                Samenumber[nownumber]++;
                //Debug.Log(x + "woshibugge" + y + " " + i + " " + ReferenceTable.turns);
            }
            else if (ReferenceTable.checkerboard[x - i, y] != 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else
            {
                //If_sleep[nownumber] = 1;
                break;
            }
        }
        //row sum
        Samenumber[nownumber]++;
        nownumber++;


        //vertical
        for (i = 1; i < 5; i++)
        {
            //up
            if (i + y > 14)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else if (ReferenceTable.checkerboard[x, y + i] == player)
            {
                Samenumber[nownumber]++;
            }
            else if (ReferenceTable.checkerboard[x, y + i] != 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else
            {
                //If_sleep[nownumber] = 1;
                break;
            }

            
        }

        for (i = 1; i < 5; i++)
        {
            //down
            if (y - i < 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else if (ReferenceTable.checkerboard[x, y - i] == player)
            {
                Samenumber[nownumber]++;
            }
            else if (ReferenceTable.checkerboard[x, y - i] != 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else
            {
                //If_sleep[nownumber] = 1;
                break;
            }
        }
        //vertical sum
        Samenumber[nownumber]++;
        nownumber++;


        //leftdown&rightup
        for (i = 1; i < 5; i++)
        {
            //rightup
            if (i + y > 14||i + x > 14)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else if (ReferenceTable.checkerboard[x + i, y + i] == player)
            {
                Samenumber[nownumber]++;
            }
            else if (ReferenceTable.checkerboard[x + i, y + i] != 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else
            {
                //If_sleep[nownumber] = 1;
                break;
            }


        }

        for (i = 1; i < 5; i++)
        {
            //leftdown
            if (y - i < 0||x - i < 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else if (ReferenceTable.checkerboard[x - i, y - i] == player)
            {
                Samenumber[nownumber]++;
            }
            else if (ReferenceTable.checkerboard[x - i, y - i] != 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else
            {
                //If_sleep[nownumber] = 1;
                break;
            }
        }
        //leftdown&rightup sum
        Samenumber[nownumber]++;
        nownumber++;


        //leftup&rightdown
        for (i = 1; i < 5; i++)
        {
            //rightdown
            if (i + x > 14 || y - i <0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else if (ReferenceTable.checkerboard[x + i, y - i] == player)
            {
                Samenumber[nownumber]++;
            }
            else if (ReferenceTable.checkerboard[x + i, y - i] != 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else
            {
                //If_sleep[nownumber] = 1;
                break;
            }


        }

        for (i = 1; i < 5; i++)
        {
            //leftup
            if (x - i < 0 || y + i > 14)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else if (ReferenceTable.checkerboard[x - i, y + i] == player)
            {
                Samenumber[nownumber]++;
            }
            else if (ReferenceTable.checkerboard[x - i, y + i] != 0)
            {
                If_sleep[nownumber] = 0;
                break;
            }
            else
            {
                //If_sleep[nownumber] = 1;
                break;
            }
        }
        //leftup&rightdown sum
        Samenumber[nownumber]++;
        nownumber++;
        return 0;
    }
	public static int Lian5(int player,int x,int y)
    {
        int i;
        Line(player, x, y);
        for (i = 0; i < 4; i++)
        {
            if (Samenumber[i] >= 5) return 0;
            //else Debug.Log(Samenumber[i]+" " +ReferenceTable.turns%2);
        }
        return 1;
    }
}
