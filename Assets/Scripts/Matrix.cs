using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public class Matrix
{
    private int[,] Data;

    public Matrix(int[,] Data)
    {
        this.Data = Data;
    } 

    public int GetRowCount() { return Data.GetLength(0); }
    public int GetColumnCount() { return Data.GetLength(1); }

    public int this[int row, int column]
    {
        get { return Data[row, column]; }
    }

    public static Matrix Multiply(Matrix LHS, Matrix RHS)
    {
        int rowMatrix1 = LHS.GetRowCount();
        int columnMatrix1 = LHS.GetColumnCount();
        int rowMatrix2 = RHS.GetRowCount();
        int columnMatrix2 = RHS.GetColumnCount();
        Assert.AreEqual(columnMatrix1, rowMatrix2);

        int[,] result = new int[rowMatrix1, columnMatrix2];
        for (int i = 0; i < rowMatrix1; i++)
        {
            for (int j = 0; j < columnMatrix2; j++)
            {
                int sum = 0;
                for (int k = 0; k < columnMatrix1; k++)
                {
                    sum += (LHS[i, k] * RHS[k, j]);
                }
                result[i, j] = sum;
            }
        }

        return new Matrix(result);
    }
}
