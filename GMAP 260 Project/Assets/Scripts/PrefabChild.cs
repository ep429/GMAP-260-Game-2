using UnityEngine;
using System.Collections;

public class PrefabChild : MonoBehaviour {

	public GameObject child;
	// Use this for initialization
	void Start () {
		GameObject parent = GameObject.Find ("Main Camera");
		child.transform.parent = parent.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
