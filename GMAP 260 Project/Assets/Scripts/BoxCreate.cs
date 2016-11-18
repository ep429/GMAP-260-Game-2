using UnityEngine;
using System.Collections;

public class BoxCreate : MonoBehaviour {

	public GameObject box;
	private GameObject prefab;
	Vector3 ray;
	RaycastHit2D hit;
	private int nextName = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousePosition = Input.mousePosition;
			ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			hit = Physics2D.Raycast (ray, mousePosition);
			Debug.Log ("Clicked");
			Debug.Log (mousePosition);
			prefab = Instantiate (box, new Vector2 (hit.point.x, hit.point.y), Quaternion.identity) as GameObject;

			prefab.name = "Box" + nextName;
			if (GameObject.Find ("Box"+(nextName-1)))
				{
					GameObject.Find ("Box"+(nextName-1).ToString()).GetComponent<Box>().enabled = false;
			
				}
			Debug.Log (nextName-1);
			nextName++;
			Debug.Log (nextName);
			if (hit.collider != null) {
				Debug.Log ("This is good");


			}
		}
			
			
	}
}

