using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public int Levels;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			GameController.currentPhase = GameController.Phase.One;
			SceneManager.LoadScene (Levels);
		}
	
	}
}
