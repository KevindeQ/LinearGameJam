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
        preMultiplyMatrixManager.Init();

        postMultiplyMatrixManager.SetMatrix(Matrix.DefaultMatrix(colCount, rowCount));
        postMultiplyMatrixManager.Init();

        player.Init();
    }
}
