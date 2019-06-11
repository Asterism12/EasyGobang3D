using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

    public GameObject blackAI;
    public GameObject whiteAI;
    public GameObject change;
    public GameObject blue;
    public GameObject tip;
    public GameObject loadandsave;
    public Text Tips;
    public Text StepNumber;
    public Text changetext;
    public Text loadorsave;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Click_s()
    {
        int i,j;
        change.SetActive(true);
        gameObject.SetActive(false);
        blackAI.SetActive(false);
        whiteAI.SetActive(false);
        tip.SetActive(true);
        loadandsave.SetActive(true);

        loadorsave.text = "读档";
        changetext.text = "落子";
        Tips.text = "黑方先行";
        StepNumber.text = "当前步数：" + ReferenceTable.turns;
        
        
        if (ReferenceTable.if_first == 0)
        {
            GameObject.Instantiate(blue, blue.transform.position, blue.transform.rotation);
            ReferenceTable.if_first = 1;
            ReferenceTable.now_position[0] = 7;
            ReferenceTable.now_position[1] = 7;
        }
        else
        {
            //GameObject.FindWithTag("Blue").GetComponent<Blue>().Movenow(7, 7);
        }
        ReferenceTable.now_if_player = 0;
        ReferenceTable.turns = 0;
        //ReferenceTable.now_position[0] = 7;
        ReferenceTable.if_start = 1;
        //ReferenceTable.now_position[1] = 7;
        ReferenceTable.Initialize();

        for (i = 0; i < 15; i++)
        {
            for (j = 0; j < 15; j++)
            {
                ReferenceTable.checkerboard[i, j] = 0;
            }
        }
    }
}
