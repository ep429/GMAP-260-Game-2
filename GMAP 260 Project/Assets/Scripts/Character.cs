using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
//	private Sprite displaySprite;

	private enum Direction
	{
		Left,
		Right}

	;

	public Vector2 displayPos;

	public Character ()
	{
		displayPos.x = 0.5f;
		displayPos.y = -15.17f;
	}

	void Start ()
	{
//		displaySprite = GetComponent<SpriteRenderer> ().sprite;

	}

	void Update ()
	{

		if (Input.anyKeyDown) {
			if (Input.GetKeyDown (KeyCode.RightArrow)) {
				GetComponent<SpriteRenderer> ().flipX = false;
				MoveBox (Direction.Right);
			} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				GetComponent<SpriteRenderer> ().flipX = true;
				MoveBox (Direction.Left);
			} 
		}
	}

	private void MoveBox (Character.Direction dir)
	{

		if (dir == Direction.Left) {
			if (displayPos.x > -3.3)
				displayPos.x = displayPos.x - 1.3f;
		} else if (dir == Direction.Right) {

			if (displayPos.x < 4.45)
				displayPos.x = displayPos.x + 1.3f;
		}

		if (GameController.currentPhase == GameController.Phase.Two) {
			if (displayPos.x < -3.3)
				displayPos.x = -3.3f;
			else if (displayPos.x > 4.45)
				displayPos.x = 4.45f;
		}

		UpdatePosition ();
	}

	public void UpdatePosition ()
	{

		Vector3 newPos;
		newPos.x = displayPos.x;
		newPos.y = -15.17f;
		newPos.z = 0;
		this.transform.position = newPos;
	}
}

