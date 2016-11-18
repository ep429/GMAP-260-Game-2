using UnityEngine;
using System.Collections;

public class PlayerLose : MonoBehaviour {

	public GameObject objText;
	// Use this for initialization
	void Start () {
		objText.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.tag == "Player") {
			Application.LoadLevel (0);
			Destroy (GameObject.FindGameObjectWithTag("Player"));
			objText.SetActive (true);
		}
	}
}
