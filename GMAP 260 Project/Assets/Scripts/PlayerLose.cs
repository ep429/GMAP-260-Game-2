using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D hit)
	{
		if (hit.gameObject.tag == "Player") {
			GameController.MaxNumBoxes = GameController.MaxNumBoxes + 1;
			GameController.currentPhase = GameController.Phase.One;
			SceneManager.LoadScene (1);
		}
	}
}
