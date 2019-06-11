using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIKind : MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Click()
    {
        if (ReferenceTable.if_defence == 0)
        {
            ReferenceTable.if_defence = 1;
            text.text = "AI类型：防守型";
        }
        else
        {
            ReferenceTable.if_defence = 0;
            text.text = "AI类型：均衡型";
        }
    }
}
