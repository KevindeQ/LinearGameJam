using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public static Matrix puzzleMatrix;

    Matrix level1matrix;
    Matrix level2matrix;

    void Start ()
    {
        level1matrix = new Matrix(new int[,]
        {
            { 1, 3 },
            { 4, 1 }
        });
        level1matrix.StartLocation = new Vector2(1, 1);

        level2matrix = new Matrix(new int[,]
        {
            { 1, 3, 2 },
            { 3, 3, 1 },
            { 2, 1, 3 }
        });
        level2matrix.StartLocation = new Vector2(2, 2);
    }

    public void ChangeLevel(string levelName)
    {
        switch (levelName)
        {
            case "L1":
                puzzleMatrix = level1matrix;
                break;
            case "L2":
                puzzleMatrix = level2matrix;
                break;
        }

        SceneManager.LoadScene(levelName);
    }
}
