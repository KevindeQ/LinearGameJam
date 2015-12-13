using UnityEngine;
using System.Collections;

public class TestInput : MonoBehaviour
{
    MatrixManager PreMultiplyMatrixManager = null;
    MatrixManager PostMultiplyMatrixManager = null;

    System.Random rnd = new System.Random();

    void Start()
    {
        PreMultiplyMatrixManager = GameObject.Find("PreMultiplyField/Visualizer").GetComponent<MatrixManager>();
        PostMultiplyMatrixManager = GameObject.Find("PostMultiplyField/Visualizer").GetComponent<MatrixManager>();
    }

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Q))
        {
            Matrix NewMatrix = GenerateRandomMatrix(
                PreMultiplyMatrixManager.GetMatrix().GetRowCount(),
                PreMultiplyMatrixManager.GetMatrix().GetColumnCount());
            PreMultiplyMatrixManager.ModifyMatrix(NewMatrix);
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            Matrix NewMatrix = GenerateRandomMatrix(
                PostMultiplyMatrixManager.GetMatrix().GetRowCount(),
                PostMultiplyMatrixManager.GetMatrix().GetColumnCount());
            PostMultiplyMatrixManager.ModifyMatrix(NewMatrix);
        }
	}

    private Matrix GenerateRandomMatrix(int RowCount, int ColumnCount)
    {
        int[,] matrix = new int[RowCount, ColumnCount];
        for(int RowIndex = 0; RowIndex < RowCount; ++RowIndex)
        {
            for(int ColumnIndex = 0; ColumnIndex < ColumnCount; ++ColumnIndex)
            {
                matrix[RowIndex, ColumnIndex] = rnd.Next(0, 2);
            }
        }

        return new Matrix(matrix);
    }
}
