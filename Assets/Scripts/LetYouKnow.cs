using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetYouKnow : MonoBehaviour {

    //public GameObject changehand;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void Click_L()
    {
        Debug.Log("as" + ReferenceTable.turns % 2 + " " + ReferenceTable.turns
            + " " + ReferenceTable.now_if_player + " " + ReferenceTable.now_position[0]
            + " " + ReferenceTable.now_position[1]);
        //changehand
        GobangAI.AImove();
    }
}
