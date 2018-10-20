using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : TouchManager {

	//private Camera c;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		Invoke ("HoopPos", .02f);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void HoopPos(){
		pos = new Vector3 (.07f, .2f, 50f);
		transform.position = TouchManager.c.ViewportToWorldPoint(pos);
	}
}
