using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour {

    public Vector3 move;
    //public GameObject cameras;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            move = new Vector3(-0.325F, 0, 0) + gameObject.transform.position;
            gameObject.transform.position = move;
            ReferenceTable.now_position[0]--;
            GameObject.Find("CenterPoint").GetComponent<Camera>().target += new Vector3(-0.325F, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            move = new Vector3(0.325F, 0, 0) + gameObject.transform.position;
            gameObject.transform.position = move;
            ReferenceTable.now_position[0]++;
            GameObject.Find("CenterPoint").GetComponent<Camera>().target += new Vector3(0.325F, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            move = new Vector3(0, 0, 0.325F) + gameObject.transform.position;
            gameObject.transform.position = move;
            ReferenceTable.now_position[1]++;
            GameObject.Find("CenterPoint").GetComponent<Camera>().target += new Vector3(0, 0, 0.325F);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            move = new Vector3(0, 0, -0.325F) + gameObject.transform.position;
            gameObject.transform.position = move;
            ReferenceTable.now_position[1]--;
            GameObject.Find("CenterPoint").GetComponent<Camera>().target += new Vector3(0, 0, -0.325F);
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            move = new Vector3(-0.325F, 0, 0) + gameObject.transform.position;
            gameObject.transform.position = move;
            ReferenceTable.now_position[0]--;
            GameObject.Find("CenterPoint").GetComponent<Camera>().target += new Vector3(-0.325F, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            move = new Vector3(0.325F, 0, 0) + gameObject.transform.position;
            gameObject.transform.position = move;
            ReferenceTable.now_position[0]++;
            GameObject.Find("CenterPoint").GetComponent<Camera>().target += new Vector3(0.325F, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            move = new Vector3(0, 0, 0.325F) + gameObject.transform.position;
            gameObject.transform.position = move;
            ReferenceTable.now_position[1]++;
            GameObject.Find("CenterPoint").GetComponent<Camera>().target += new Vector3(0, 0, +0.325F);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move = new Vector3(0, 0, -0.325F) + gameObject.transform.position;
            gameObject.transform.position = move;
            ReferenceTable.now_position[1]--;
            GameObject.Find("CenterPoint").GetComponent<Camera>().target += new Vector3(0, 0, -0.325F);
        }

        //Debug.Log(move);
        
        //move = new Vector3(0, 0, 0);
    }
    public void Movenow(int x,int y)
    {
        int xm, ym;
        xm = x - ReferenceTable.now_position[0];
        ym = y - ReferenceTable.now_position[1];
        move = new Vector3(0, 0, 0.325F * ym) + new Vector3(0.325F * xm,0,0)+gameObject.transform.position;
        gameObject.transform.position = move;
        ReferenceTable.now_position[0] = x;
        ReferenceTable.now_position[1] = y;

        if (ReferenceTable.turns % 2 == 1)
        {
            GameObject.Find("CenterPoint").GetComponent<Camera>().target +=
            new Vector3(0, 0, 0.325F * ym) + new Vector3(0.325F * xm, 0, 0);
        }
        else
        {
            GameObject.Find("CenterPoint").GetComponent<Camera>().target +=
            new Vector3(0, 0, 0.325F * ym) + new Vector3(0.325F * xm, 0, 0);
        }
        
        //move = new Vector3(0, 0, 0);
        return;
    }
}
