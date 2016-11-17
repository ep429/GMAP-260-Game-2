using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{
	public Vector2 displayPos;
	private Sprite box;

	enum Direction
	{
		Up,
		Down,
		Left,
		Right}

	;

	void Start ()
	{

		box = GetComponent<SpriteRenderer> ().sprite;
	}

	public Box ()
	{
		displayPos.x = 0.5f;
		displayPos.y = 0.5f;
	}

	void Update ()
	{
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

		UpdatePosition ();

	}

	public void UpdatePosition ()
	{

		Vector3 newPos;
		newPos.x = displayPos.x;
		newPos.y = displayPos.y;
		newPos.z = 0;
		this.transform.position = newPos;
	}

	public void drop ()
	{
		
		Vector3 newPos;
		newPos.x = displayPos.x;
		newPos.y = displayPos.y;
		newPos.z = 0;
		--displayPos.y;

		this.transform.position = newPos;

		if (displayPos.y <= -17) {
			SpriteRenderer r = GetComponent<SpriteRenderer> ();
			r.enabled = false;
		}
	}
}

