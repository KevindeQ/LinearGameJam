using UnityEngine;
using System.Collections;

public class MatrixMultiplication : MonoBehaviour {

	int[, ] matrix = new int[, ]
	{
		{ 1, 1, 1},
		{ 1, 1, 1},
		{ 1, 1, 1},
	};
	int[, ] matrix2 = new int[, ]
	{
		{ 2, 2, 2},
		{ 2, 2, 2},
		{ 2, 2, 2},
	};

	public int [,] MatrixMult(int[,] matrix1, int[,] matrix2) {
		int [,] result = new int[,]{};

		int rowMatrix1 = matrix1.GetLength(0);
		int columnMatrix1 = matrix1.GetLength(1);
		int columnMatrix2 = matrix2.GetLength(1);

		for (int i = 0; i < rowMatrix1; i++) {
			for (int j = 0; j < columnMatrix2; j++) {
				int sum = 0;
				for (int k = 0; k < columnMatrix1; k++) {
					sum = sum + (matrix1[i,k] * matrix2[k,j]);
				}
				result[i,j] = sum;
			}
		}
		return result;
	}

	void ShowMatrix(int[,] matrix) {
		
		int rowMatrix = matrix.GetLength(0);
		int columnMatrix = matrix.GetLength(1);

		for (int n = 0; n < columnMatrix; n++) {
			string temp = "";
			for (int m = 0; m < rowMatrix; m++) {
				temp = temp + " " + matrix[n,m];
			}
			Debug.Log (temp);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f")) {
			int [,] temp = new int[,]{};
			temp = MatrixMult(matrix, matrix2);
			ShowMatrix(temp);
		}
	}
}
