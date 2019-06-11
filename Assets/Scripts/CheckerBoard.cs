using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerBoard : MonoBehaviour {

    private float number;
    private float scape = 0.1F;
    public int direction;

    // Use this for initialization
    void Start () {
        number = 0;
        direction = 3;
    }
	
	// Update is called once per frame
	void Update () {
        if (direction == 0)
        {
            if (number <= 40)
            {
                transform.Rotate(new Vector3(0, 0, scape));
                number += scape;
                if (scape < 4) scape = scape + 0.1F;
            }
            if (number > 40 && number < 80)
            {
                if (number + scape > 80)
                    scape = 80 - number;
                transform.Rotate(new Vector3(0, 0, scape));
                number += scape;
                if (scape > 0.1) scape = scape - 0.1F;
            }
            if (number == 80)
            {
                direction = 1;
                scape = 0.1F;
                number = 0;
            }
        }
        if (direction == 1)
        {
            if (number <= 40)
            {
                transform.Rotate(new Vector3(0, 0, -scape));
                number += scape;
                if (scape < 4) scape = scape + 0.1F;
            }
            if (number > 40 && number < 80)
            {
                if (number + scape > 80)
                {
                    scape = 80 - number;
                    //Debug.Log(number + " " + scape);
                }
                    
                transform.Rotate(new Vector3(0, 0, -scape));
                number += scape;
                if (scape > 0.1) scape = scape - 0.1F;
            }
            if (number == 80)
            {
                direction = 2;
                scape = 0.1F;
                number = 0;
            }
        }
    }
}
