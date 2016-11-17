using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
	private Sprite displaySprite;

	private enum Direction
	{
		Left,
		Right}

	;

	public Vector2 displayPos;

	public Character ()
	{
		displayPos.x = 0.5f;
		displayPos.y = -16.5f;
	}

	void Start ()
	{

		displaySprite = GetComponent<SpriteRenderer> ().sprite;
	}

	void Update ()
	{

		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {

				MoveBox (Direction.Right);
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {

				MoveBox (Direction.Left);
			} 
		}
	}

	private void MoveBox (Character.Direction dir)
	{

		if (dir == Direction.Left) {

			if (displayPos.x > -4.5)
				displayPos.x = displayPos.x - 1;
		} else if (dir == Direction.Right) {

			if (displayPos.x < 4.5)
				displayPos.x = displayPos.x + 1;
		}

		UpdatePosition ();
	}

	public void UpdatePosition ()
	{

		Vector3 newPos;
		newPos.x = displayPos.x;
		newPos.y = -16.5f;
		newPos.z = 0;
		this.transform.position = newPos;
	}
}

