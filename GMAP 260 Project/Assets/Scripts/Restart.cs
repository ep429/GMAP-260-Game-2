using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public int Levels;
	public int maxBoxes = 4;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			maxBoxes = maxBoxes + 1;
			GameController.currentPhase = GameController.Phase.One;
			GameController.MaxNumBoxes = maxBoxes;
			SceneManager.LoadScene (Levels);
		}
	
	}
}
