using UnityEngine;
using System.Collections;

public class MatrixManager : MonoBehaviour {
	public Transform tower;

	int[, ] matrix;

	// Use this for initialization
	void Start () {
		matrix = new int[, ] {
			{ 1, 2 },
			{ 3, 4 }
		};

		int columns = matrix.GetLength(0);
		int rows = matrix.GetLength(1);

		for (int x = 0; x < columns; x++) {
			for (int z = 0; z < rows; z++) {
				Vector3 position = new Vector3(x - columns / 2.0f, matrix[x, z], z - rows / 2.0f);
				Transform obj = (Transform)Instantiate(tower, position, Quaternion.identity);
				obj.parent = transform;
			}
		}
	}

	// Update is called once per frame
	void Update () {}
}