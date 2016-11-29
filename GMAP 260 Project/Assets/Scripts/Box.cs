using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
	private Vector2 displayPos;
//	private Sprite box;

	public GameObject boxes;

	enum Direction
	{
		Up,
		Down,
		Left,
		Right}

	;

	void Start ()
	{

//		box = GetComponent<SpriteRenderer> ().sprite;
		//GetComponent<Rigidbody2D> ().gravityScale = 0;
	}

	public Box ()
	{
		displayPos.x = Mathf.Round(BoxCreate.hit.point.x)/2;
		displayPos.y = Mathf.Round(BoxCreate.hit.point.y)/2;
	}

	void Update ()
	{
		Debug.Log (displayPos.x);
		Debug.Log (displayPos.y);
		if (GameController.currentPhase == GameController.Phase.One) {
			if (Input.anyKeyDown) {

				if (Input.GetKeyDown (KeyCode.RightArrow)) {

					MoveBox (Direction.Right);
				} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {

					MoveBox (Direction.Left);
				} else if (Input.GetKeyDown (KeyCode.UpArrow)) {

					MoveBox (Direction.Up);
				} else if (Input.GetKeyDown (KeyCode.DownArrow)) {

					MoveBox (Direction.Down);
				}

			}
		}
			
	}

	private void MoveBox (Box.Direction dir)
	{

		if (dir == Direction.Down) {

			if (displayPos.y > -4.5)
				--displayPos.y;
		} else if (dir == Direction.Up) {

			if (displayPos.y < 4.5)
				++displayPos.y;
		} else if (dir == Direction.Left) {

			if (displayPos.x > -4.5)
				--displayPos.x;
		} else if (dir == Direction.Right) {

			if (displayPos.x < 4.5)
				++displayPos.x;
		}

		if (GameController.currentPhase == GameController.Phase.One) {
			if (displayPos.x < -4.5)
				displayPos.x = -4.5f;
			else if (displayPos.x > 4.5)
				displayPos.x = 4.5f;
			else if (displayPos.y < -4.5)
				displayPos.y = -4.5f;
			else if (displayPos.y > 4.5)
				displayPos.y = 4.5f;
		}

		UpdatePosition ();

	}

	public void UpdatePosition ()
	{

		//displayPos.x = GetComponent<Rigidbody2D>().position.x;
		//displayPos.y = GetComponent<Rigidbody2D> ().position.y;

		Vector3 newPos;
		newPos.x = displayPos.x;
		newPos.y = displayPos.y;
		newPos.z = 0;
		GetComponent<Rigidbody2D>().position = newPos;
	}

	public void drop ()
	{
		//displayPos.x = GetComponent<Rigidbody2D>().position.x;
		//displayPos.y = GetComponent<Rigidbody2D> ().position.y;
		GetComponent<SpriteRenderer> ().enabled = false;
		Vector3 newPos;
		newPos.x = displayPos.x;
		newPos.y = displayPos.y;
		newPos.z = 0;
		if (GameController.currentPhase == GameController.Phase.Two) {
			GetComponent<SpriteRenderer> ().enabled = true;
			//GetComponent<Rigidbody2D> ().gravityScale = .1f;
		}
		displayPos.y--;
		GetComponent<Rigidbody2D>().position = newPos;


		if (displayPos.y <= -18) {
			Destroy (this.gameObject);
		}
	}


}

