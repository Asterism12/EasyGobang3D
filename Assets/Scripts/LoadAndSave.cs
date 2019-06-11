using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAndSave : MonoBehaviour {

    public GameObject checkerboard;
    public GameObject changehand;
    public GameObject black;
    public GameObject white;
    public GameObject InputField;

    public Text Tips;

    private GameObject blue;
    private Vector3 location;

    // Use this for initialization
    void Start () {
        
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Click()
    {
        changehand.SetActive(false);
        if (ReferenceTable.turns > 0)
        {
            //GUI.TextField(new Rect(0,0,20,20),"text");
            InputField.SetActive(true);
            //Save();
            
        }
        else
        {
            InputField.SetActive(true);
            //Load();
            ReferenceTable.if_loading = 1;
            
        }
    }
    private void Putdown(int x,int y,int player)
    {
        blue = GameObject.FindWithTag("Blue");
        blue.GetComponent<Blue>().Movenow(x, y);
        location = blue.transform.position;
        if (player == 1)
        {
            GameObject.Instantiate(black, location, black.transform.rotation);
        }
        else
        {
            GameObject.Instantiate(white, location, white.transform.rotation);
        }
    }
    public void Load(string name)
    {
        //checkerboard.GetComponent<CheckerBoard>().direction = 0;
        
        ReferenceTable.checkerboard = PrefsX.GetIntArray("CheckerBoard"+name);
        ReferenceTable.turns = PlayerPrefs.GetInt("turns");
        for(int i = 0; i < 15; i++)
        {
            for(int j = 0; j < 15; j++)
            {
                if (ReferenceTable.checkerboard[i, j] == 1)
                {
                    Putdown(i, j, 1);
                }
                if (ReferenceTable.checkerboard[i, j] == 2)
                {
                    Putdown(i, j, 2);
                }
            }
        }
        ReferenceTable.if_loading = 0;
        
        if (ReferenceTable.turns % 2 == 1)
        {
            Tips.text = "读取成功，现在轮到白方走棋";
        }
        else
        {
            Tips.text = "读取成功，现在轮到黑方走棋";

        }
        changehand.SetActive(true);
    }
    public void Save(string name)
    {
        PrefsX.SetIntArray("CheckerBoard" + name, ReferenceTable.checkerboard);
        PlayerPrefs.SetInt("turns", ReferenceTable.turns);
        Debug.Log("save success");
        Tips.text = "保存成功";
        changehand.SetActive(true);
    }
}
