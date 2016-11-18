using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	Box[] boxes;
	Character character;

	public enum Phase
	{
		One,


		Two}

	;

	private float BoxDropSpeed = 2.0f;
	private GameController instance = null;

	public static GameController.Phase currentPhase = Phase.One;
	public static bool GameOver = false;

	public GameController ()
	{

	}

	void Start ()
	{

		character = new Character ();



	}

	void Update ()
	{
		boxes = GetComponentsInChildren<Box> ();

		if (boxes.Length > 3) {
			GameObject.Find ("Main Camera").GetComponent<BoxCreate> ().enabled = false;
		} else {
			GameObject.Find ("Main Camera").GetComponent<BoxCreate> ().enabled = true;
		}

		if (Input.GetKeyDown (KeyCode.Return) && boxes.Length == 0) {
			GameOver = true;
			Application.LoadLevel (0);
		}

		for (int i = 0; i < boxes.Length; i++) {

			if (character.displayPos == boxes [i].displayPos) {

				GameOver = true;
				Application.LoadLevel (0);
			} 
		}

			
	}

	public void UpdatePhase (Phase p)
	{

		currentPhase = p;
		if (currentPhase == Phase.Two) {
			StartCoroutine (DropBoxes ());
		}
		
	}

	public IEnumerator DropBoxes ()
	{

		while (!GameOver) {

			// drop blocks
			for (int i = 0; i < boxes.Length; i++) {
				boxes [i].drop ();
				yield return new WaitForSeconds (BoxDropSpeed);
			}
		}
			

		yield return 0;

	}
}

