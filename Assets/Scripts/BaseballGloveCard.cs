using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballGloveCard : TouchManager {

	//private Camera c;
	private Vector3 pos;
	// Use this for initialization
	void Start () {
		Invoke ("GlovePos", .02f);
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	void GlovePos(){
		c = Camera.main;
		pos = new Vector3 (.07f, .8f, 50f);
		transform.position = TouchManager.c.ViewportToWorldPoint(pos);
	}
}
