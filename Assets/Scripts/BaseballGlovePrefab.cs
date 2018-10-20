using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballGlovePrefab : TouchManager {

	public int dragging;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void InvokeInactivate(){
		Invoke ("Inactive", 3f);
	}

	public void Inactive(){
		transform.position = Camera.main.ViewportToWorldPoint (new Vector3 (-.5f, .8f, 50f));
		dragging = 0;
	}

}