using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	Box[] boxes;
	//Character character;
//	private int countNum;

	public enum Phase
	{
		One,


		Two}

	;

	public float BoxDropSpeed;
//	private GameController instance = null;
	public static GameController.Phase currentPhase = Phase.One;
	public bool GameOver = false;
	public GameController ()
	{

	}

	void Start ()
	{

		//character = new Character ();
		currentPhase = Phase.One;
	}

	void Update ()
	{
		GameObject g = GameObject.Find ("Background");
		boxes = GameObject.Find ("Background").GetComponentsInChildren<Box> ();

		if (boxes.Length > 4) {
			GameObject.Find ("Background").GetComponent<BoxCreate> ().enabled = false;
		} else {
			if (currentPhase == Phase.Two) {
				GameObject.Find ("Background").GetComponent<BoxCreate> ().enabled = false;
			} else {
				GameObject.Find ("Background").GetComponent<BoxCreate> ().enabled = true;
			}
		}

		if (currentPhase == Phase.One) {
			if (boxes.Length == 0 && Input.GetKeyDown (KeyCode.Return)) {
				currentPhase = Phase.One;
				SceneManager.LoadScene (2);
			}
		}
		Debug.Log (currentPhase);
		Debug.Log (GameOver);
		if (currentPhase == Phase.Two) {
			if (boxes.Length == 0) {
				currentPhase = Phase.One;
				SceneManager.LoadScene (2);

			}
		}
			

		/*for (int i = 0; i < boxes.Length; i++) {

			if (character.displayPos == boxes [i].displayPos) {
				GameOver = true;
				currentPhase = Phase.One;
				Box.count = 0;
				SceneManager.LoadScene(0);

			} 
		}*/

			
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

	/*void OnCollisionEnter2D(Collider2D hit)
	{
		if (hit.gameObject.tag == "Box") {
			GameOver = true;
			currentPhase = Phase.One;
			Box.count = 0;
			SceneManager.LoadScene(0);
		}
	}*/


}

