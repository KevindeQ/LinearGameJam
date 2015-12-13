using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public static Matrix puzzleMatrix;

    Matrix level1matrix;
    Matrix level2matrix;
    Matrix level3matrix;

    void Start ()
    {
        level1matrix = new Matrix(new int[,]
        {
            { 1, 3 },
            { 4, 1 }
        });
        level1matrix.StartLocation = new Vector2(1, 1);
        level1matrix.BananaLocation = new Vector2(-1, -1);

        level2matrix = new Matrix(new int[,]
        {
            { 1, 3, 2 },
            { 3, 3, 1 },
            { 2, 1, 3 }
        });
        level2matrix.StartLocation = new Vector2(2, 2);
        level2matrix.BananaLocation = new Vector2(-1, -1);


        level3matrix = new Matrix(new int[,]
        {
            { 3, 5, 1, 3 },
            { 1, 6, 3, 2 },
            { 3, 1, 3, 4 },
            { 5, 1, 3, 2 }
        });
        level3matrix.StartLocation = new Vector2(3, 3);
        level3matrix.BananaLocation = new Vector2(2, 3);
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
            case "L3":
                puzzleMatrix = level3matrix;
                break;
        }

        SceneManager.LoadScene(levelName);
		//Application.LoadLevel (levelName);
    }
}
