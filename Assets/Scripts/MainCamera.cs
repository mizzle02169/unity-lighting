using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCamera : MonoBehaviour {



	// Use this for initialization
	void Awake () {
		

	}

	void Start () {
		Camera.main.orthographicSize = Screen.height / 2.0f;
		Camera.main.aspect = (float)Screen.width/Screen.height;

	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
