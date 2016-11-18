using UnityEngine;
using System.Collections;

public class BoxDestroy : MonoBehaviour {

	public GameObject box;
	private GameObject prefab;
	Vector2 ray;
	RaycastHit2D hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {

			Vector3 mousePosition = Input.mousePosition;
			ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			hit = Physics2D.Raycast (ray, Vector2.zero);

			/*if (box.tag == "Box") {
				GameObject clone = prefab;
				Debug.Log ("Hit");
				Destroy (clone);
			}*/
			if (hit.collider != null)
			{
				if (hit.collider.tag == "Box") {
					Destroy (hit.collider.gameObject);
				}

			}
	
	}
}
}
