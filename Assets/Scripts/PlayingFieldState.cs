using UnityEngine;
using System.Collections;

public class PlayingFieldState : MonoBehaviour
{
    MatrixManager PuzzleMatrixManager = null;
    MatrixManager PreMultiplyMatrixManager = null;
    MatrixManager PostMultiplyMatrixManager = null;

	void Start()
    {
        PuzzleMatrixManager = GameObject.Find("PuzzleField/Visualizer").GetComponent<MatrixManager>();
        PreMultiplyMatrixManager = GameObject.Find("PreMultiplyField/Visualizer").GetComponent<MatrixManager>();
        PostMultiplyMatrixManager = GameObject.Find("PostMultiplyField/Visualizer").GetComponent<MatrixManager>();
	}
	
	void Update()
    {
        if (PreMultiplyMatrixManager.IsModified || PostMultiplyMatrixManager.IsModified)
        {
            Matrix NewMatrix = Matrix.Multiply(PreMultiplyMatrixManager.GetMatrix(), PuzzleMatrixManager.GetMatrix());
            NewMatrix = Matrix.Multiply(NewMatrix, PostMultiplyMatrixManager.GetMatrix());

            PuzzleMatrixManager.ModifyMatrix(NewMatrix);
        }
    }
}
