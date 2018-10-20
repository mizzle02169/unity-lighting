using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingToss : TouchManager {

	//private Camera c;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		Invoke ("RingTossPos", .02f);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void RingTossPos(){
		pos = new Vector3 (.07f, .4f, 50f);
		transform.position = TouchManager.c.ViewportToWorldPoint(pos);
	}
}
