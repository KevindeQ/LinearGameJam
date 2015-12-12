using UnityEngine;
using System.Collections;

public class MatrixMultiplication : MonoBehaviour {

	int[, ] matrix = new int[, ]
	{
		{ 8, 9, 8, 2},
		{ 3, 5, 6, 1},
		{ 2, 3, 5, 3},
	};
	int[, ] matrix2 = new int[, ]
	{
		{ 8, 3, 1},
		{ 1, 4, 8},
		{ 3, 4, 1},
		{ 4, 2, 3},
	};

	public int [,] MatrixMult(int[,] matrix1, int[,] matrix2) {

		int rowMatrix1 = matrix1.GetLength(0);
		int columnMatrix1 = matrix1.GetLength(1);
		int columnMatrix2 = matrix2.GetLength(1);
		int [,] result = new int[rowMatrix1,columnMatrix2];

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
			int [,] temp = new int[99,99];
			temp = MatrixMult(matrix, matrix2);
			ShowMatrix(temp);
		}
	}
}
