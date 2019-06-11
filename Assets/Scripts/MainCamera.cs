using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private float number;
    public float target;
    private float scape = 0.5F;

    // Use this for initialization
    void Start () {
        number = 60;
        target = 60;
	}
	
	// Update is called once per frame
	void Update () {
        if (target - number > 0)
        {
            transform.Rotate(new Vector3(scape, 0, 0));
            number += 0.5f;
        }
        if(target - number < 0)
        {
            transform.Rotate(new Vector3(-scape, 0, 0));
            number -= 0.5f;
        }
	}
}
