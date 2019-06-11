using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackAI : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Click()
    {
        if (ReferenceTable.black_if_player == 1)
        {
            ReferenceTable.black_if_player = 0;
            text.text = "黑方：计算机";
        }

        else
        {
            ReferenceTable.black_if_player = 1;
            text.text = "黑方：玩家";
        }
            
    }
}
