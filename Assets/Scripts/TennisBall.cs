using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : TouchManager {

	public int dragging;
	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = transform.GetComponent<Rigidbody> ();
		Invoke ("launch", .03f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (3, 4, 4);
	}

	void FixedUpdate(){
		//rb.AddTorque (100, 100, 100);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag("TennisRacket")){
			TouchManager.score = TouchManager.score + 1;
		}
	}

	void launch(){
		rb.velocity = new Vector3 (100, 550, 0);

	}
}
