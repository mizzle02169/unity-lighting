using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisRacket : TouchManager {

	//private Camera c;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		//c = Camera.main;
		Invoke ("TennisRacketPos", .02f);
	}

	// Update is called once per frame
	void Update () {

	}

	void TennisRacketPos(){

		pos = new Vector3 (.07f, .6f, 50f);
		transform.position = TouchManager.c.ViewportToWorldPoint(pos);
	}
		
}

