using UnityEngine;
using System.Collections;

public class MatrixMultiplication : MonoBehaviour {

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
}
