using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	Box[] boxes;
	Character character;
	public enum Phase {One, Two};
	private float BoxDropSpeed = 1.0f;
	private GameController instance = null;

	public static GameController.Phase currentPhase = Phase.One;
	public static bool GameOver = false;

	public GameController(){

	}

	void Start(){

		character = new Character ();
		currentPhase = Phase.One;
		boxes = GetComponentsInChildren<Box> ();

	}

	public void UpdatePhase(Phase p){

		currentPhase = p;
		if (currentPhase == Phase.Two) {
			StartCoroutine (DropBoxes ());
		}
		
	}

	public IEnumerator DropBoxes(){

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

