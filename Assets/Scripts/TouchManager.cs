using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour {

	public static Camera c;
	public int tennisBatStart, tennisBatEnd;
	public int baseballGloveStart, baseballGloveEnd;
	public GameObject[] gameObjects;
	private Ray ray;
	private RaycastHit hit;
	private Vector2 startPos;
	private Vector3 v3;
	public GameObject[] cards;
	private GameObject selectedCard;
	public Renderer[] outlines;
	public GameObject movingObject = null;
	public static int score;
	public Text scoreText;
	public static Vector3[] spawnPoints = new Vector3[8];
	public static Vector3 inactivePosition;

	void Start(){

		c = Camera.main;
		Invoke ("resizeObjects", .01f);
		selectedCard = cards [0];
		Invoke ("setSpawnPositions", .02f);

	}

	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount > 0) {

			//Toucn touch = Input.GetTouch (0);

			// Handle finger movements based on touch phase.
			switch (Input.GetTouch(0).phase)
			{
			// Record initial touch position.
			case TouchPhase.Began:
				
				startPos = Input.GetTouch (0).position;

				v3.x = startPos.x;
				v3.y = startPos.y;
				v3.z = 0;
				v3 = Camera.main.ScreenToWorldPoint (v3);

				ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

				if (Physics.Raycast (ray, out hit )) {

					if (hit.transform.name == "BaseballGloveOutline") {
						selectedCard = cards [0];
						outlines [0].enabled = true;
						outlines [1].enabled = false;
						outlines [2].enabled = false;
						outlines [3].enabled = false;

						for (int i = baseballGloveStart; i <= baseballGloveEnd; i++) {
							if (gameObjects [i].GetComponent<TennisBatPrefab> ().dragging != 1) {
								gameObjects [i].GetComponent<TennisBatPrefab> ().dragging = 1;
								movingObject = gameObjects [i];
								break;
							}
						}
						movingObject.transform.position = new Vector3 (v3.x, v3.y, 0);

					} else if (hit.transform.name == "TennisBatOutline") {
						selectedCard = cards [1];
						outlines [1].enabled = true;
						outlines [0].enabled = false;
						outlines [2].enabled = false;
						outlines [3].enabled = false;

						for (int i = tennisBatStart; i <= tennisBatEnd; i++) {
							if (gameObjects [i].GetComponent<TennisBatPrefab> ().dragging != 1) {
								gameObjects [i].GetComponent<TennisBatPrefab> ().dragging = 1;
								movingObject = gameObjects [i];
								break;
							}
						}
						movingObject.transform.position = new Vector3 (v3.x, v3.y, 0);

					} else if (hit.transform.name == "RingTossOutline") {
						selectedCard = cards [2];
						outlines [2].enabled = true;
						outlines [0].enabled = false;
						outlines [1].enabled = false;
						outlines [3].enabled = false;

					} else if (hit.transform.name == "HoopOutline") {
						selectedCard = cards [3];
						outlines [3].enabled = true;
						outlines [0].enabled = false;
						outlines [1].enabled = false;
						outlines [2].enabled = false;

					}

				}
				break;

				// Determine direction by comparing the current touch position with the initial one.
			case TouchPhase.Moved:
				Vector3 moving;
				moving.x = Input.GetTouch (0).position.x;
				moving.y = Input.GetTouch (0).position.y;
				moving.z = 0;
				moving = Camera.main.ScreenToWorldPoint (moving);
				if (movingObject) {
					movingObject.transform.position = new Vector3 (moving.x, moving.y, 0);
				}
				break;

				// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
				if (movingObject) {
					movingObject.GetComponent<TennisBatPrefab> ().InvokeInactivate ();
					movingObject = null;
				}
				break;
			}
		}

		selectedCard.transform.Rotate (Vector3.up * Time.deltaTime * 90);
		addScore ();
	}

	void resizeObjects(){
		float scale;
		scale = Screen.height/720.0f;

		foreach (GameObject obj in gameObjects) {
			float x;
			float y;
			float z;
			x = obj.transform.localScale.x * scale;
			y = obj.transform.localScale.y * scale;
			z = obj.transform.localScale.z * scale;
			obj.transform.localScale = new Vector3 (x, y, z);
		}

	}

	void addScore(){
		scoreText.text = "Score: " + score.ToString ();
	}

	void setSpawnPositions(){
		spawnPoints [0] = c.ViewportToWorldPoint (new Vector3 (.2f, -.1f, 50f));
		spawnPoints [1] = c.ViewportToWorldPoint (new Vector3 (.375f, -.1f, 50f));
		spawnPoints [2] = c.ViewportToWorldPoint (new Vector3 (.55f, -.1f, 50f));
		spawnPoints [3] = c.ViewportToWorldPoint (new Vector3 (.725f, -.1f, 50f));
		spawnPoints [4] = c.ViewportToWorldPoint (new Vector3 (.9f, -.1f, 50f));
		spawnPoints [5] = c.ViewportToWorldPoint (new Vector3 (1.1f, .75f, 50f));
		spawnPoints [6] = c.ViewportToWorldPoint (new Vector3 (1.1f, .5f, 50f));
		spawnPoints [7] = c.ViewportToWorldPoint (new Vector3 (1.1f, .25f, 50f));

		inactivePosition = c.ViewportToWorldPoint(new Vector3 (-.5f, .5f, 50f));
	
	}
		
}
	