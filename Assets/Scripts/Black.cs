using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < -2)
        {
            //Debug.Log("asdf");
            Destroy(gameObject,3);
        }
	}
}
