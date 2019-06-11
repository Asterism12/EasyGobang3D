using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Vector3 target;
    public int rote;
    public int if_win;
	// Use this for initialization
	void Start () {
        target = transform.localPosition;
        if_win = 0;
        rote = 45;
	}
	
	// Update is called once per frame
	void Update () {
        if (if_win == 0)
        {
            Vector3 det = target - transform.localPosition;
            det = 0.05f * det;
            transform.localPosition += det;
            //Quaternion detr = rota - transform.rotation;
            //Vector3 detr = rota.ToEuler() - transform.rotation.ToEuler();
            //Vector3 detr = rota.eulerAngles - transform.rotation.eulerAngles;
            //transform.rotation = Quaternion.Euler(detr);
            //transform.Rotate(detr);
            //transform.Rotate(new Vector3(0, rote, 0));
            //rote = 0;
        }
        else
        {
            //rote = 45;
            
            //transform.rotation.x = 30;
            Vector3 det = target - transform.localPosition + new Vector3(0, -1.2f, 0);
            det = 0.02f * det;
            transform.localPosition += det;
            //transform.Rotate(new Vector3(0, 1, 0));
            //rote++;
            //rote %= 360;
        }
	}
    public void Roteing(int target)
    {
        //Vector3 detr = new Vector3(60, 0, 0);
        //detr = 0.05f * detr;
        GameObject.Find("Main Camera").GetComponent<MainCamera>().target = target;
    }
}
