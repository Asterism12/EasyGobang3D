using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteAI : MonoBehaviour {

    public Text text;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        if (ReferenceTable.white_if_player == 1)
        {
            ReferenceTable.white_if_player = 0;
            text.text = "白方：计算机";
        }

        else
        {
            ReferenceTable.white_if_player = 1;
            text.text = "白方：玩家";
        }

    }
}
