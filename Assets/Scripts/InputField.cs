using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour {

    //public Text text;
    public GameObject Loadandsave;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void End_value1(Text text)
    {
        if (ReferenceTable.if_loading == 1)
        {
            Loadandsave.GetComponent<LoadAndSave>().Load(text.text);
        }
        else
        {
            Loadandsave.GetComponent<LoadAndSave>().Save(text.text);
        }
        gameObject.SetActive(false);
    }
    
}
