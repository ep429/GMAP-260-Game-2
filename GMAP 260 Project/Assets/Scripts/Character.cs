using UnityEngine;
using System.Collections;

	public class Character : MonoBehaviour
	{
		private Sprite displaySprite;
		private enum Direction {Left, Right};
		Vector2 displayPos;
		int gridXPos;
		
		public Character ()
		{
			displayPos.x = 0.5f;
			displayPos.y = -16.5f;
			gridXPos = 5;
		}

	void Start(){


		displaySprite = GetComponent<SpriteRenderer> ().sprite;

	}

		void Update(){

			if (Input.anyKeyDown) {
				if (Input.GetKeyDown (KeyCode.RightArrow)) {

					MoveBox (Direction.Right);
				} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {

					MoveBox (Direction.Left);
				} 
			}
		}

		private void MoveBox(Character.Direction dir){

			if (dir == Direction.Left) {

				if (displayPos.x > -4.5)
					displayPos.x = displayPos.x - 1;
				if (gridXPos > 0)
					--gridXPos;
			}

			else if (dir == Direction.Right) {

				if (displayPos.x < 4.5)
					displayPos.x = displayPos.x + 1;
				if (gridXPos < 10)
					++gridXPos;
			}

			UpdatePosition ();
		}

		public void UpdatePosition(){

			Vector3 newPos;
			newPos.x = displayPos.x;
			newPos.y = -16.5f;
			newPos.z = 0;
			this.transform.position = newPos;
		}
	}

