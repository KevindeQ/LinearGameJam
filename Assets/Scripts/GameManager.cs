using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public MatrixManager puzzleMatrixManager;
    public MatrixManager preMultiplyMatrixManager;
    public MatrixManager postMultiplyMatrixManager;

    public PlayerManager player;

    void Start ()
    {
        int colCount = MenuManager.puzzleMatrix.GetColumnCount();
        int rowCount = MenuManager.puzzleMatrix.GetRowCount();

        puzzleMatrixManager.SetMatrix(MenuManager.puzzleMatrix);
        puzzleMatrixManager.Init();

        preMultiplyMatrixManager.SetMatrix(Matrix.DefaultMatrix(colCount, rowCount));
        Matrix preMatrix = preMultiplyMatrixManager.GetMatrix();
        preMatrix.StartLocation = new Vector2(preMatrix.GetColumnCount() - 1, preMatrix.GetRowCount() - 1);
        preMultiplyMatrixManager.Init();

        postMultiplyMatrixManager.SetMatrix(Matrix.DefaultMatrix(colCount, rowCount));
        Matrix postMatrix = postMultiplyMatrixManager.GetMatrix();
        postMatrix.StartLocation = new Vector2(postMatrix.GetColumnCount() - 1, postMatrix.GetRowCount() - 1);
        postMultiplyMatrixManager.Init();

        player.Init();
    }
}
