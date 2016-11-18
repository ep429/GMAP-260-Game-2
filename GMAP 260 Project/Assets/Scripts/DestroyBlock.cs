using UnityEngine;
using System.Collections;

public class DestroyBlock : MonoBehaviour {

	public GameObject boxes;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.tag == "Delete") {
			Destroy (gameObject);
		}
	}
}