using UnityEngine;
using System.Collections;

public class GridSystem : MonoBehaviour {

	int[][] grid;
	int numRows = 10;
	int numCols = 10;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < numRows; ++i)
		{
			for (int j = 0; j < numCols; j++) 
			{
				grid [i] [j] = 0;
			}
		}


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
