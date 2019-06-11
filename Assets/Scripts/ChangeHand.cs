using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHand : MonoBehaviour {

    private Vector3 location;
    public GameObject black;
    public GameObject white;
    public GameObject checkerboard;
    public GameObject startbutton;
    public GameObject blackAI;
    public GameObject whiteAI;
    public GameObject tip;
    public GameObject centerpoint;
    public AudioSource play;
    //public GameObject loadandsave;
    private GameObject blue;
    public Text Tips;
    public Text StepNumber;
    public Text ButtonText;
    public Text Loadorsave;

    public void Click()
    {
        
        if (ReferenceTable.if_start == 1)
        {
            if (ReferenceTable.turns == 0)
            {
                Loadorsave.text = "存档";
            }
            play.Play();
            //Debug.Log("first?");
            blue = GameObject.FindWithTag("Blue");
            location = blue.transform.position;
            if (Bordercheck() == 0)
            {
                if (ReferenceTable.checkerboard[ReferenceTable.now_position[0], ReferenceTable.now_position[1]] == 0)
                {
                    gameObject.SetActive(false);
                    if (ReferenceTable.turns % 2 != 1)
                    {
                        //centerpoint.GetComponent<Camera>().Roteing(45);
                        GameObject.Instantiate(black, location, black.transform.rotation);
                        Tips.text = "轮到白方行棋";
                        ReferenceTable.checkerboard[
                            ReferenceTable.now_position[0], ReferenceTable.now_position[1]] = 1;
                        ReferenceTable.now_if_player = ReferenceTable.white_if_player;
                        if (Wincheck(1, ReferenceTable.now_position[0], ReferenceTable.now_position[1]) == 0)
                        {
                            Tips.text = "黑方获胜";
                            ReferenceTable.turns++;

                            //tip.SetActive(false);
                            centerpoint.GetComponent<Camera>().if_win = 1;
                            centerpoint.GetComponent<Camera>().Roteing(45);

                            ReferenceTable.if_start = 0;
                            StepNumber.text = "当前步数：" + ReferenceTable.turns;
                            ButtonText.text = "重新开始";
                            gameObject.SetActive(true);
                            
                        }
                        else
                        {
                            ReferenceTable.Addturns();
                            StepNumber.text = "当前步数：" + ReferenceTable.turns;
                            //Debug.Log(SituationCheck.Samenumber[2]+ " "+SituationCheck.Samenumber[3]);
                        }
                    }
                    else
                    {
                        GameObject.Instantiate(white, location, white.transform.rotation);
                        Tips.text = "轮到黑方行棋";
                        ReferenceTable.checkerboard[
                            ReferenceTable.now_position[0], ReferenceTable.now_position[1]] = 2;
                        ReferenceTable.now_if_player = ReferenceTable.black_if_player;
                        if (Wincheck(2, ReferenceTable.now_position[0], ReferenceTable.now_position[1]) == 0)
                        {
                            Tips.text = "白方获胜";
                            
                            ReferenceTable.Addturns();
                            StepNumber.text = "当前步数：" + ReferenceTable.turns;

                            //tip.SetActive(false);
                            centerpoint.GetComponent<Camera>().if_win = 1;
                            centerpoint.GetComponent<Camera>().Roteing(45);

                            ButtonText.text = "重新开始";
                            gameObject.SetActive(true);
                            ReferenceTable.if_start = 0;
                        }
                        else
                        {
                            ReferenceTable.Addturns();
                            //Debug.Log(ReferenceTable.now_if_player);
                            StepNumber.text = "当前步数：" + ReferenceTable.turns;
                            //Debug.Log(SituationCheck.Samenumber[2] + " " + SituationCheck.Samenumber[3]);
                        }
                    }
                    if (ReferenceTable.turns >= 225)
                    {
                        Tips.text = "和棋";
                    }
                }
                else
                {
                    Tips.text = "这个位置已经存在棋子";
                }
            }
            else
            {
                Tips.text = "超出边界";
            }
        }
        else
        {
            checkerboard.GetComponent<CheckerBoard>().direction = 0;

            centerpoint.GetComponent<Camera>().if_win = 0;
            centerpoint.GetComponent<Camera>().Roteing(60);
            //tip.SetActive(false);
            ReferenceTable.if_start = 0;
            blue.GetComponent<Blue>().Movenow(7, 7);
            gameObject.SetActive(false);
            startbutton.SetActive(true);
            blackAI.SetActive(true);
            whiteAI.SetActive(true);
        }
    }

    private int Bordercheck()
    {
        if (ReferenceTable.now_position[0] < 0 || ReferenceTable.now_position[0] > 14)
            return 1;
        else if (ReferenceTable.now_position[1] < 0 || ReferenceTable.now_position[1] > 14)
            return 1;
        else
            return 0;
    }

    private int Wincheck(int player,int x,int y)
    {
        return SituationCheck.Lian5(player, x, y);
    }

    //private int

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Click();
        }
	}

}
