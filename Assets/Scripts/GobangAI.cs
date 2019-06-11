using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GobangAI  {
    public static int[,,] Valuemap = new int[15, 15, 2];

    public static void Valueini()
    {
        int i, j, k;
        for (i = 0; i < 15; i++)
        {
            for (j = 0; j < 15; j++)
            {
                for (k = 0; k < 2; k++)
                {
                    Valuemap[i, j, k] = 0;
                }
            }
        }
        return ;
    }

    public static void AImove()
    {
        //ReferenceTable.now_if_player = ReferenceTable.black_if_player;
        int me = ReferenceTable.turns % 2;
        int oppose = (me + 1) % 2;

        //Debug.Log("adf");
        Valueini();
        Valuecal();

        int i, j, maxattack = -1, maxdefence = -1, x = 7, y = 7;
        //check attack & defence
        for (i = 0; i < 15; i++)
        {
            for (j = 0; j < 15; j++)
            {
                if (Valuemap[i, j, me] > maxattack)
                {
                    maxattack = Valuemap[i, j, me];
                    x = i;
                    y = j;
                }
            }
        }
        for (i = 0; i < 15; i++)
        {
            for (j = 0; j < 15; j++)
            {
                if (Valuemap[i, j, oppose] > maxdefence)
                {
                    maxdefence = Valuemap[i, j, oppose];
                }
            }
        }
        if (ReferenceTable.if_defence == 1)
        {
            maxdefence += 200;
        }
        if (maxattack >= maxdefence)
        {
            maxdefence = -1;
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    if (Valuemap[i, j, me] == maxattack)
                    {
                        if (Valuemap[i, j, oppose] > maxdefence)
                        {
                            maxdefence = Valuemap[i, j, oppose];
                            x = i;
                            y = j;
                        }
                    }
                }
            }
            //Debug.Log("attack");
            GameObject.FindWithTag("Blue").GetComponent<Blue>().Movenow(x,y);
        }
        else
        {
            if (ReferenceTable.if_defence == 1)
            {
                maxdefence -= 200;
            }
            maxattack = -1;
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    if (Valuemap[i, j, oppose] == maxdefence)
                    {
                        if (Valuemap[i, j, me] > maxattack)
                        {
                            maxattack = Valuemap[i, j, me];
                            x = i;
                            y = j;
                        }
                    }
                }
            }
            //Debug.Log("defence");
            GameObject.FindWithTag("Blue").GetComponent<Blue>().Movenow(x, y);
        }
        //Debug.Log(x + "  " + y + " " + maxattack + " " + maxdefence);
        //GameObject.Find("ChangeHand").GetComponent<ChangeHand>().Click();
        return;
    }
    public static void Valuecal()
    {
        int[,] sum = new int[5,2];
        int i, j, k,a,b;


        for (i = 0; i < 15; i++)
        {
            for (j = 0; j < 15; j++)
            {
                //if_have_piece
                if (ReferenceTable.checkerboard[i, j] != 0)
                {
                    Valuemap[i, j, 0] = 0;
                    Valuemap[i, j, 1] = 0;
                }
                else
                {
                    //black
                    //ini
                    for (a = 0; a < 5; a++)
                    {
                        for (b = 0; b < 2; b++)
                        {
                            sum[a, b] = 0;
                        }
                    }
                    SituationCheck.Line(1, i, j);
                    for (k = 0; k < 4; k++)
                    {
                        if (SituationCheck.If_sleep[k] == 1)
                        {
                            sum[SituationCheck.Samenumber[k] - 1, 0]++;
                        }
                        else if (SituationCheck.If_sleep[k] == 0)
                        {
                            sum[SituationCheck.Samenumber[k] - 1, 1]++;
                        }
                    }
                    if (sum[4, 0] != 0 || sum[4, 1] != 0)
                    {
                        //live five
                        Valuemap[i, j, 0] = 100000;
                    }
                    else if (sum[3, 0] >= 2)
                    {
                        //double four
                        Valuemap[i, j, 0] = 10000 + sum[3, 0];
                    }
                    else if (sum[3, 1] >= 1 && sum[2, 0] >= 1)
                    {
                        //dead four & live three
                        Valuemap[i, j, 0] = 10000 + sum[3, 1] + sum[2, 0];
                    }
                    else if (sum[3, 1] >= 2 || sum[3, 0] >= 1)
                    {
                        //double dead four | live four
                        Valuemap[i, j, 0] = 10000 + sum[3, 1] + sum[3, 0];
                    }
                    else if (sum[2, 0] >= 2)
                    {
                        //double three
                        Valuemap[i, j, 0] = 5000 + sum[2, 0];
                    }
                    else if (sum[2, 0] >= 1 && sum[2, 1] >= 1)
                    {
                        //dead three &live three
                        Valuemap[i, j, 0] = 1000 + sum[2, 0] + sum[2, 1];
                    }
                    else if (sum[3, 1] >= 1)
                    {
                        //dead four
                        Valuemap[i, j, 0] = 500 + sum[3, 1];
                    }
                    else if (sum[2, 0] >= 1)
                    {
                        //live three
                        Valuemap[i, j, 0] = 100 + sum[2, 0];
                    }
                    else if (sum[1, 0] >= 2)
                    {
                        //double live two
                        Valuemap[i, j, 0] = 50 + sum[1, 0];
                    }
                    else if (sum[1, 0] >= 1)
                    {
                        //live two
                        Valuemap[i, j, 0] = 10 + sum[1, 0];
                    }
                    else if (sum[2, 1] >= 1)
                    {
                        //dead three
                        Valuemap[i, j, 0] = 5 + sum[2, 1];
                    }
                    else if (sum[1, 1] >= 1)
                    {
                        //dead two
                        Valuemap[i, j, 0] = 2 + sum[1, 1];
                    }
                    else Valuemap[i, j, 0] = 1;
                    //Debug.Log(sum[1, 0]);
                    
                    //Debug.Log(i+" "+j);

                    //white
                    //ini
                    for (a = 0; a < 5; a++)
                    {
                        for (b = 0; b < 2; b++)
                        {
                            sum[a, b] = 0;
                        }
                    }
                    SituationCheck.Line(2, i, j);
                    for (k = 0; k < 4; k++)
                    {
                        if (SituationCheck.If_sleep[k] == 1)
                        {
                            sum[SituationCheck.Samenumber[k] - 1, 0]++;
                        }
                        else if (SituationCheck.If_sleep[k] == 0)
                        {
                            sum[SituationCheck.Samenumber[k] - 1, 1]++;
                        }
                    }
                    if (sum[4, 0] != 0 || sum[4, 1] != 0)
                    {
                        //live five
                        Valuemap[i, j, 1] = 100000;
                    }
                    else if (sum[3, 0] >= 2)
                    {
                        //double four
                        Valuemap[i, j, 1] = 10000 + sum[3, 0];
                    }
                    else if (sum[3, 1] >= 1 && sum[2, 0] >= 1)
                    {
                        //dead four & live three
                        Valuemap[i, j, 1] = 10000 + sum[3, 1] + sum[2, 0];
                    }
                    else if (sum[3, 1] >= 2 || sum[3, 0] >= 1)
                    {
                        //double dead four | live four
                        Valuemap[i, j, 1] = 10000 + sum[3, 1] + sum[3, 0];
                    }
                    else if (sum[2, 0] >= 2)
                    {
                        //double three
                        Valuemap[i, j, 1] = 5000 + sum[2, 0];
                    }
                    else if (sum[2, 0] >= 1 && sum[2, 1] >= 1)
                    {
                        //dead three &live three
                        Valuemap[i, j, 1] = 1000 + sum[2, 0] + sum[2, 1];
                    }
                    else if (sum[3, 1] >= 1)
                    {
                        //dead four
                        Valuemap[i, j, 1] = 500 + sum[3, 1];
                    }
                    else if (sum[2, 0] >= 1)
                    {
                        //live three
                        Valuemap[i, j, 1] = 100 + sum[2, 0];
                    }
                    else if (sum[1, 0] >= 2)
                    {
                        //double live two
                        Valuemap[i, j, 1] = 50 + sum[1, 0];
                    }
                    else if (sum[1, 0] >= 1)
                    {
                        //live two
                        Valuemap[i, j, 1] = 10 + sum[1, 0];
                        //Debug.Log(i + " w " + j + " w " + sum[1, 0]);
                    }
                    else if (sum[2, 1] >= 1)
                    {
                        //dead three
                        Valuemap[i, j, 1] = 5 + sum[2, 1];
                    }
                    else if (sum[1, 1] >= 1)
                    {
                        //dead two
                        Valuemap[i, j, 1] = 2 + sum[1, 1];
                    }
                    else Valuemap[i, j, 1] = 1;
                }
            }
            //Debug.Log(i + " " + j);
        }
        return ;
    }
	
}
