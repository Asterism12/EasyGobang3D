using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour {

    public GameObject changehand;
    public float number;
    private float scape = 0.1F;

    // Use this for initialization
    void Start () {
        number = 181;
	}
	
	// Update is called once per frame
	void Update () {
        if (number <= 90)
        {
            transform.Rotate(new Vector3(0, scape, 0));
            number += scape;
            if (scape < 4.5) scape = scape + 0.1F;
        }
        if (number > 90 && number < 180)
        {
            if (number + scape > 180)
                scape = 180 - number;
            transform.Rotate(new Vector3(0, scape, 0));
            number += scape;
            if (scape > 0.1) scape = scape - 0.1F;
        }
        if (number == 180)
        {
            if (ReferenceTable.now_if_player == 1)
            {
                changehand.SetActive(true);
                number = 181;
            }
            else
            {
                GobangAI.AImove();
                changehand.GetComponent<ChangeHand>().Click();
                
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
