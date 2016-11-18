﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour {

	public float speed = 2.5f;
	public Transform squareChange;
	public Transform squareStart;
	public GameObject objText;
	public GameObject parent;
	public GameObject child; 
	private bool press = true;
	private bool onText = false;
	// Use this for initialization

	public GameController g;

	void Start () {
		child.transform.parent = parent.transform;
		objText.SetActive (false);
		g = FindObjectOfType<GameController> ();
		GameObject.Find ("Character").GetComponent<Character> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {

		if (onText == false) {
			if (Input.GetKeyDown (KeyCode.Return)) {
				onText = true;
				StartCoroutine (ShowText ());
				GameObject.Find ("New Sprite").GetComponent<Box>().enabled = false;
				GameObject.Find ("New Prefab").GetComponent<Box>().enabled = false;
				GameObject.Find ("Character").GetComponent<Character> ().enabled = false;
				GameObject.Find ("Main Camera").GetComponent<BoxCreate> ().enabled = false;


			}
		} else if (onText == true) {
				if (Input.GetKeyDown (KeyCode.Return) && press) {
					StartCoroutine (TransitionDown ());
					press = !press;
					onText = false;
					StartCoroutine (ShowText ());
					GameObject.Find ("Character").GetComponent<Character> ().enabled = true;
					
				} else if (Input.GetKeyDown (KeyCode.Return) && !press) {
					StartCoroutine (TransitionUp ());
					press = !press;
					onText = false;
					StartCoroutine (ShowText ());
					GameObject.Find ("New Sprite").GetComponent<Box>().enabled = true;
					GameObject.Find ("New Prefab").GetComponent<Box>().enabled = true;
					GameObject.Find ("Main Camera").GetComponent<BoxCreate> ().enabled = true;
					
					
				}
			}
		}

	IEnumerator TransitionDown()
	{
		
			float i = 0.0f;
			Vector3 start1 = transform.position;
			while (i < 1.0f)
			{
				i += Time.deltaTime * (Time.timeScale / speed);
				Vector3 pos1 = new Vector3 (transform.position.x, squareChange.position.y, transform.position.z);
				transform.position = Vector3.Lerp (start1,pos1,i);
				yield return 0;
			}

		g.UpdatePhase (GameController.Phase.Two);
	}

	IEnumerator TransitionUp()
	{

		float j = 0.0f;
		Vector3 start2 = transform.position;
		while (j < 1.0f)
		{
			j += Time.deltaTime * (Time.timeScale / speed);
			Vector3 pos2 = new Vector3 (transform.position.x, squareStart.position.y, transform.position.z);
			transform.position = Vector3.Lerp (start2,pos2,j);
			yield return 0;
		}
	}

	public IEnumerator ShowText()
	{
		if (objText == true)
		{
			objText.SetActive (onText);
		}
		else
		{
		}

		yield return 0;

	}
		
}
			
