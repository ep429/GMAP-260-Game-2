using UnityEngine;
using System.Collections;

	public class Box : MonoBehaviour
	{
		Vector2 displayPos, gridPos;
		private Sprite box;

		enum Direction {Up, Down, Left, Right}; 

		void Start (){

			box = GetComponent<SpriteRenderer> ().sprite;
		}
		public Box ()
		{
			displayPos.x = 0.5f;
			displayPos.y = 0.5f;
			gridPos.x = 5;
			gridPos.y = 5;
			
		}

		void Update()
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

		private void MoveBox(Box.Direction dir){

			if (dir == Direction.Down) {

				if (displayPos.y > -4.5)
					--displayPos.y;
				if (gridPos.y > 0)
					--gridPos.y;
			}

			else if (dir == Direction.Up) {

				if (displayPos.y < 4.5)
					++displayPos.y;
				if (gridPos.y < 10)
					++gridPos.y;
			}

			else if (dir == Direction.Left) {

				if (displayPos.x > -4.5)
					--displayPos.x;
				if (gridPos.x > 0)
					--gridPos.x;
			}

			else if (dir == Direction.Right) {

				if (displayPos.x < 4.5)
					++displayPos.x;
				if (gridPos.x < 10)
					++gridPos.x;
			}

			UpdatePosition ();

		}

		public void UpdatePosition(){

			Vector3 newPos;
			newPos.x = displayPos.x;
			newPos.y = displayPos.y;
			newPos.z = 0;
			this.transform.position = newPos;
		}

		public void drop(){
		
			Vector3 newPos;
			newPos.x = displayPos.x;
			newPos.y = displayPos.y;
			newPos.z = 0;
			--displayPos.y;

		this.transform.position = newPos;

			if (displayPos.y < -16.5) {
				SpriteRenderer r = GetComponent<SpriteRenderer> ();
				r.enabled = false;
			}
		}
	}

