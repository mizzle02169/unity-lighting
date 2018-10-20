﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBatCollider : TouchManager {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag("TennisBall")){
			transform.parent.position = TouchManager.inactivePosition; 
		}
	}
}
